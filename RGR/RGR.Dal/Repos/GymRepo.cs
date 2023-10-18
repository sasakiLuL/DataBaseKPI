using Npgsql;
using RGR.Dal.Filters;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;
using System.Data;

namespace RGR.Dal.Repos
{
    public class GymRepo : BaseRepo<Gym>
    {
        public GymRepo(NpgsqlConnection connection) : base(connection) { }

        public IEnumerable<(Gym Entity, long UsersCount, long CoachesCount)> FindWithUserAndCoachesCount
            (Filter<(Gym Entity, long UsersCount, long CoachesCount)> filter)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = @$"select subq.gym_id, subq.gym_name, subq.address, subq.home_page, 
	  		                                subq.phone_number, subq.email, subq.description, subq.gym_type,
			                                subq.UsersCount, count(coach_id) as CoachesCount
                                from (	select gyms.gym_id, gyms.gym_name, gyms.address, gyms.home_page, 
	  		                                gyms.phone_number, gyms.email, gyms.description, gyms.gym_type, 
	  		                                count(gyms_participants.user_id) as UsersCount
		                                from gyms
   		                                inner join gyms_participants on gyms_participants.gym_id = gyms.gym_id
		                                group by gyms.gym_id, gyms.gym_name, gyms.address, gyms.home_page, 
	  			                                gyms.phone_number, gyms.email, gyms.description, gyms.gym_type
	                                 ) as subq
                                full join coaches on coaches.gym_id = subq.gym_id
                                where {filter.QueryString}
                                group by subq.gym_id, subq.gym_name, subq.address, subq.home_page, 
	  		                                subq.phone_number, subq.email, subq.description, subq.gym_type,
			                                subq.UsersCount
                                order by subq.gym_id;"
            };

            command.Parameters.AddRange(filter.Parameters.ToArray());

            Connection.Open();

            using NpgsqlDataReader reader = command.ExecuteReader();

            List<(Gym Entity, long UsersCount, long CoachesCount)> resultList = new();

            while (reader.Read())
            {
                (Gym Entity, long UsersCount, long CoachesCount) record = new();
                record.Entity = new Gym();

                Columns.ForEach(column =>
                {
                    Properties[column].SetValue(record.Entity, reader[column] != DBNull.Value ? reader[column] : null);
                });

                Properties[Key].SetValue(record.Entity, reader[Key]);

                record.UsersCount = (long)reader["UsersCount"];

                record.CoachesCount = (long)reader["CoachesCount"];

                resultList.Add(record);
            }

            Connection.Close();

            return resultList;
        }
    }
}