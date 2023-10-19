using Npgsql;
using RGR.Dal.Filters;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;
using System.Data;

namespace RGR.Dal.Repos
{
    public class UserRepo : BaseRepo<User>
    {
        public UserRepo(NpgsqlConnection connection) : base(connection) { }

        public (IEnumerable<(User Entity, long ContractsCount)>, string) FindUsersContracts(Filter<(User Entity, long ContractsCount)> filter)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = @$"select user_id, first_name, last_name, sex, date_of_birth, phone, address, email, count(contract_id) contracts_count
                                    from users full join contracts using(user_id) 
                                    where {filter.QueryString}
                                    group by user_id, first_name, last_name, sex, date_of_birth, phone, address, email
                                    order by user_id;"
            };

            command.Parameters.AddRange(filter.Parameters.ToArray());

            var explainCommand = command.Clone();
            explainCommand.CommandText = "EXPLAIN ANALYZE " + explainCommand.CommandText;

            Connection.Open();

            using NpgsqlDataReader reader = command.ExecuteReader();

            List<(User Entity, long ContractsCount)> resultList = new();

            while (reader.Read())
            {
                (User Entity, long ContractsCount) record = new();
                record.Entity = new User();

                Columns.ForEach(column =>
                {
                    Properties[column].SetValue(record.Entity, reader[column] != DBNull.Value ? reader[column] : null);
                });

                Properties[Key].SetValue(record.Entity, reader[Key]);

                record.ContractsCount = (long)reader["contracts_count"];

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
