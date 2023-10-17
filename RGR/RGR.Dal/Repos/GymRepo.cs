using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;
using System.Data;

namespace RGR.Dal.Repos
{
    public class GymRepo : BaseRepo<Gym>
    {
        public GymRepo(NpgsqlConnection connection) : base(connection) { }

        public IEnumerable<(Gym Entity, long UsersCount, long CoachesCount)> FindAllWithUserAndCoachesCount()
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = @$"select subq.gym_id, subq.gym_name, subq.address, subq.home_page, 
	  		                                subq.phone_number, subq.email, subq.description, subq.gym_type,
			                                subq.user_count, count(coach_id) as coach_count
                                from (	select gyms.gym_id, gyms.gym_name, gyms.address, gyms.home_page, 
	  		                                gyms.phone_number, gyms.email, gyms.description, gyms.gym_type, 
	  		                                count(gyms_participants.user_id) as user_count
		                                from gyms
   		                                inner join gyms_participants on gyms_participants.gym_id = gyms.gym_id
		                                group by gyms.gym_id, gyms.gym_name, gyms.address, gyms.home_page, 
	  			                                gyms.phone_number, gyms.email, gyms.description, gyms.gym_type
	                                 ) as subq
                                full join coaches on coaches.gym_id = subq.gym_id
                                group by subq.gym_id, subq.gym_name, subq.address, subq.home_page, 
	  		                                subq.phone_number, subq.email, subq.description, subq.gym_type,
			                                subq.user_count
                                order by subq.gym_id;"
            };

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

                record.UsersCount = (long)reader["user_count"];

                record.CoachesCount = (long)reader["coach_count"];

                resultList.Add(record);
            }

            Connection.Close();

            return resultList;
        }
    }
}