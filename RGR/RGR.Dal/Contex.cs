using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace RGR.Dal
{
    public class Contex
    {
        protected NpgsqlConnection _connection;
        public Contex(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public void CommandNoQuery(string query, params (string name, NpgsqlDbType type, object value)[] paraments)
        {
            _connection.Open();

            using var command = _connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            foreach (var param in paraments)
            {
                var dbParam = new NpgsqlParameter()
                {
                    ParameterName = param.name,
                    Value = param.value,
                    NpgsqlDbType = param.type
                };
                command.Parameters.Add(dbParam);
            }

            command.ExecuteNonQuery();

            _connection.Close();
        }
        public IEnumerable<Dictionary<string, object>> Command(string query, params (string name, NpgsqlDbType type, object value)[] paraments)
        {
            var outList = new List<Dictionary<string, object>>();

            _connection.Open();

            using var command = _connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            foreach (var param in paraments)
            {
                var dbParam = new NpgsqlParameter()
                {
                    ParameterName = param.name,
                    Value = param.value,
                    NpgsqlDbType = param.type
                };
                command.Parameters.Add(dbParam);
            }

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dict.Add(reader.GetName(i), reader.GetValue(i));
                }
                outList.Add(dict);
            }

            _connection.Close();

            return outList;
        }
    }
}
