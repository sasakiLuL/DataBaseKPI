using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;
using System.Data;
using RGR.Dal.Filters;

namespace RGR.Dal.Repos
{
    public class ClassRepo : BaseRepo<Class>
    {
        public ClassRepo(NpgsqlConnection connection) : base(connection) {}

        public (IEnumerable<(Class Entity, string CourseName, long ParticipantCount)>, string) FindFullClassInfo(Filter<(Class Entity, string CourseName, long ParticipantCount)> filter)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = @$"select 
	                                class_id, max_participants, course_id, start_time, end_time, course_name as CourseName, count(user_id) as ParticipantCount
                                from 
	                                classes
                                full join courses using(course_id)
                                full join classes_participants using(class_id)
                                where {filter.QueryString}
                                group by class_id, max_participants, start_time, end_time, course_id, CourseName
                                order by class_id;"
            };

            command.Parameters.AddRange(filter.Parameters.ToArray());

            var explainCommand = command.Clone();
            explainCommand.CommandText = "EXPLAIN ANALYZE " + explainCommand.CommandText;

            Connection.Open();

            using NpgsqlDataReader reader = command.ExecuteReader();

            List<(Class Entity, string CourseName, long ParticipantCount)> resultList = new();

            while (reader.Read())
            {
                (Class Entity, string CourseName, long ParticipantCount) record = new();
                record.Entity = new Class();

                Columns.ForEach(column =>
                {
                    Properties[column].SetValue(record.Entity, reader[column] != DBNull.Value ? reader[column] : null);
                });

                Properties[Key].SetValue(record.Entity, reader[Key]);

                record.CourseName = (string)reader["CourseName"];

                record.ParticipantCount = (long)reader["ParticipantCount"];

                resultList.Add(record);
            }

            string time = "";

            using NpgsqlDataReader explainReader = explainCommand.ExecuteReader();

            while (explainReader.Read())
            {
                time = (string)explainReader.GetValue(0);
            }

            Connection.Close();

            return (resultList, time);
        }
    }
}
