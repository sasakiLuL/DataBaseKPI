using Npgsql;
using RGR.Dal.Filters;
using RGR.Dal.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;

namespace RGR.Dal.Repos.BaseRepo
{
    public class BaseRepo<TEntity> : IRepo<TEntity> where TEntity : class, new()
    {
        protected Type ClassType { get; private set; }

        protected NpgsqlConnection Connection { get; private set; }

        public string Key { get; private set; }

        public List<string> Columns { get; private set; }

        public string TableName { get; private set; }

        public Dictionary<string, PropertyInfo> Properties { get; private set; }

        public BaseRepo(NpgsqlConnection connection)
        {
            ClassType = typeof(TEntity);
            Connection = connection;
            Key = string.Empty;
            Columns = new List<string>();
            Properties = new Dictionary<string, PropertyInfo>();

            TableName = ClassType.GetCustomAttribute<TableAttribute>()?.Name ?? ClassType.Name;

            foreach (var property in ClassType.GetProperties())
            {
                string column = property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name;

                Properties.Add(column, property);

                if (property.GetCustomAttribute<KeyAttribute>() != null)
                    Key = column;
                else
                    Columns.Add(column);
            }
        }

        public string Add(TEntity entity)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
            };

            Columns.ForEach((column) => command.Parameters.Add(new NpgsqlParameter()
            {
                ParameterName = "@PARAM_" + column.ToUpper(),
                Value = Properties[column].GetValue(entity) != null ? Properties[column].GetValue(entity) : DBNull.Value
            }));

            string columnsString = AggregateStringWithSeparators(Columns, (str) => str.ToString());
            string paramNamesString = AggregateStringWithSeparators(command.Parameters, (param) => param.ParameterName);

            command.CommandText = $"EXPLAIN ANALYZE INSERT INTO {TableName} ({columnsString}) VALUES ({paramNamesString});";

            Connection.Open();

            using var reader = command.ExecuteReader();

            string time = "";

            while (reader.Read())
            {
                time = (string)reader.GetValue(0);
            }

            Connection.Close();

            return time;
        }

        public string Delete(long id)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = $"EXPLAIN ANALYZE DELETE FROM {TableName} WHERE {Key} = @PARAM_ID;"
            };
            command.Parameters.Add(new NpgsqlParameter() {
                ParameterName = "@PARAM_ID",
                Value = id
            });

            Connection.Open();

            using var reader = command.ExecuteReader();

            string time = "";

            while (reader.Read())
            {
                time = (string)reader.GetValue(0);
            }

            Connection.Close();

            return time;
        }

        public string Update(long id, TEntity entity)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
            };

            Columns.ForEach((column) => command.Parameters.Add(new NpgsqlParameter()
            {
                ParameterName = "@PARAM_" + column.ToUpper(),
                Value = Properties[column].GetValue(entity) != null ? Properties[column].GetValue(entity) : DBNull.Value
            }));
            command.Parameters.Add(new NpgsqlParameter()
            {
                ParameterName = "@PARAM_ID",
                Value = id
            });

            string variablesString = AggregateStringWithSeparators(Columns.Zip(command.Parameters), (pair) => $"{pair.First} = {pair.Second.ParameterName}");

            command.CommandText = $"EXPLAIN ANALYZE UPDATE {TableName} SET {variablesString} WHERE {Key} = @PARAM_ID;";

            Connection.Open();

            using var reader = command.ExecuteReader();

            string time = "";

            while (reader.Read())
            {
                time = (string)reader.GetValue(0);
            }

            Connection.Close();

            return time;
        }

        public (IEnumerable<TEntity>, string) Find(Filter<TEntity> filter)
        {
            IList<TEntity> entities = new List<TEntity>();

            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = $"SELECT * FROM {TableName} WHERE {filter.QueryString} ORDER BY {Key};"
            };

            command.Parameters.AddRange(filter.Parameters.ToArray());

            var explainCommand = command.Clone();
            explainCommand.CommandText = "EXPLAIN ANALYZE " + explainCommand.CommandText;

            Connection.Open();

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TEntity entity = ClassType.GetConstructor(Type.EmptyTypes)?.Invoke(null) as TEntity;

                    Columns.ForEach(column =>
                    {
                        Properties[column].SetValue(entity, reader[column] != DBNull.Value ? reader[column] : null);
                    });

                    Properties[Key].SetValue(entity, reader[Key]);

                    entities.Add(entity);
                }
            }

            string time = "";

            using NpgsqlDataReader explainReader = explainCommand.ExecuteReader();

            while (explainReader.Read())
            {
                time = (string)explainReader.GetValue(0);
            }

            Connection.Close();

            return (entities, time);
        }

        public (IEnumerable<TEntity>, string) FindAll()
        {
            IList<TEntity> entities = new List<TEntity>();

            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = $"SELECT * FROM {TableName} ORDER BY {Key};"
            };

            var explainCommand = command.Clone();
            explainCommand.CommandText = "EXPLAIN ANALYZE " + explainCommand.CommandText;

            Connection.Open();

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TEntity entity = ClassType.GetConstructor(Type.EmptyTypes)?.Invoke(null) as TEntity;

                    Columns.ForEach(column =>
                    {
                        Properties[column].SetValue(entity, reader[column] != DBNull.Value ? reader[column] : null);
                    });

                    Properties[Key].SetValue(entity, reader[Key]);

                    entities.Add(entity);
                }
            }

            string time = "";

            using NpgsqlDataReader explainReader = explainCommand.ExecuteReader();

            while (explainReader.Read())
            {
                time = (string)explainReader.GetValue(0);
            }

            Connection.Close();

            return (entities, time);
        }

        public void Generate(long count)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
            };

            List<string> query = new List<string>();

            Columns.ForEach((column) => {
                var fKey = Properties[column].GetCustomAttribute<ForeignKeyAttribute>().Name;
                if (fKey != null)
                {
                    Type t = fKey switch
                    {
                        "Class" => typeof(Class),
                        "Coach" => typeof(Coach),
                        "Contract" => typeof(Contract),
                        "ContractTerms" => typeof(ContractTerms),
                        "Course" => typeof(Course),
                        "Gym" => typeof(Gym),
                        "User" => typeof(User),
                        _ => throw new NotImplementedException()
                    };
                    query.Add(GenerateRandomForeightKeyQuery(t.GetProperties().Where(p => 
                        p.GetCustomAttribute<KeyAttribute>() != null).FirstOrDefault().Name,
                        t.GetCustomAttribute<TableAttribute>().Name));

                    return;
                }

                switch (Properties[column].DeclaringType.Name)
                {
                    case nameof(Int32):
                        query.Add(GenerateRandomIntQuery(50));
                        break;

                    case nameof(DateTime):
                        query.Add(GenerateRandomTimeStampQuery("2000-10-19 08:00:00", "2023-10-19 08:00:00"));
                        break;

                    case nameof(DateOnly):
                        query.Add(GenerateDateQuery("2000-10-19", "2023-10-19"));
                        break;

                    case nameof(String):
                        query.Add(GenerateRandomStringQuery(20));
                        break;
                }
            });

            string columnsString = AggregateStringWithSeparators(Columns, (str) => str.ToString());
            string paramNamesString = AggregateStringWithSeparators(query, (param) => param);

            command.CommandText = $"INSERT INTO {TableName} ({columnsString}) VALUES ({paramNamesString})";

            for (long i = 0; i < count; i++) 
            {
                command.ExecuteNonQuery();
            }
        }

        protected string GenerateRandomStringQuery(int lenght)
        {
            string generateCharQuery = "chr(trunc(65 + random() * 25)::int)";
            string resulQuery = string.Empty;
            for (int i = 0; i < lenght; i++)
            {
                if (i != lenght - 1)
                    resulQuery += generateCharQuery + " || ";
                else
                    resulQuery += generateCharQuery;
            }
            return generateCharQuery;
        }

        protected string GenerateRandomIntQuery(int maxValue)
        {
            return $"trunc(1 + random() * {maxValue})::int";
        }

        protected string GenerateRandomTimeStampQuery(string firstDate, string secondDate)
        {
            return $"timestamp '{firstDate}' + random() * (timestamp '{secondDate}' - timestamp '{firstDate}')";
        }

        protected string GenerateDateQuery(string firstDate, string secondDate)
        {
            return $"date '{firstDate}' + (random() * (date '{secondDate}' - date '{firstDate}'))::int";
        }

        protected string GenerateRandomForeightKeyQuery(string column, string table)
        {
            return $"(random() * (select max({column}) from {table}) + 1)::bigint";
        }

        private string AggregateStringWithSeparators<TOut>(IEnumerable<TOut> list, Func<TOut, string> convertor)
        {
            string outStr = list.SkipLast(1).Aggregate(string.Empty, (str, next) => str += convertor(next) + ", ");
            outStr += convertor(list.Last());
            return outStr;
        }
    }
}
