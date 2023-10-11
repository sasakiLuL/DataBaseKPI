using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace RGR.Dal.Repos.BaseRepo
{
    public class BaseRepo<T> : IRepo<T> where T : class, new()
    {
        protected Type ClassType { get; private set; }

        protected NpgsqlConnection Connection { get; private set; }

        public string Key { get; private set; }

        public List<string> Columns { get; private set; }

        public string TableName { get; private set; }

        protected Dictionary<string, PropertyInfo> Properties { get; private set; }

        public BaseRepo(NpgsqlConnection connection)
        {
            ClassType = typeof(T);
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

        public void Add(T entity)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
            };

            Columns.ForEach((column) => command.Parameters.Add(new NpgsqlParameter()
            {
                ParameterName = "@PARAM_" + column.ToUpper(),
                Value = Properties[column].GetValue(entity)
            }));

            string columnsString = AggregateStringWithSeparators(Columns, (str) => str.ToString());
            string paramNamesString = AggregateStringWithSeparators(command.Parameters, (param) => param.ParameterName);

            command.CommandText = $"INSERT INTO {TableName} ({columnsString}) VALUES ({paramNamesString});";

            Connection.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
            
            Connection.Close();
        }

        public void Delete(int id)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
                CommandText = $"DELETE FROM {TableName} WHERE {Key} = @PARAM_ID;"
            };
            command.Parameters.Add(new NpgsqlParameter() {
                ParameterName = "@PARAM_ID",
                Value = id
            });

            Connection.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Connection.Close();
        }

        public void Update(int id, T entity)
        {
            NpgsqlCommand command = new NpgsqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = Connection,
            };

            Columns.ForEach((column) => command.Parameters.Add(new NpgsqlParameter()
            {
                ParameterName = "@PARAM_" + column.ToUpper(),
                Value = Properties[column].GetValue(entity)
            }));
            command.Parameters.Add(new NpgsqlParameter()
            {
                ParameterName = "@PARAM_ID",
                Value = id
            });

            string variablesString = AggregateStringWithSeparators(Columns.Zip(command.Parameters), (pair) => $"{pair.First} = {pair.Second.ParameterName}");

            command.CommandText = $"UPDATE {TableName} SET {variablesString} WHERE {Key} = @PARAM_ID;";

            Connection.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Connection.Close();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        private string AggregateStringWithSeparators<TOut>(IEnumerable<TOut> list, Func<TOut, string> convertor)
        {
            string outStr = list.SkipLast(1).Aggregate(string.Empty, (str, next) => str += convertor(next) + ", ");
            outStr += convertor(list.Last());
            return outStr;
        }
    }
}
