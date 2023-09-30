using Npgsql;
using System.Data;

namespace RGR.Dal.Repos.Base
{
    public abstract class BaseRepo<T> : IRepo<T> where T : new()
    {
        protected DataSet _set;
        protected NpgsqlConnection _connection;
        protected NpgsqlDataAdapter _adapter;
        protected BaseRepo(NpgsqlConnection connection, params string[] tablesNames)
        {
            _connection = connection;
            _set = new DataSet();
            _adapter = new NpgsqlDataAdapter();

            _connection.Open();

            string selectCmd = "";

            foreach (var name in tablesNames)
            {
                selectCmd += $"SELECT * FROM {name};";
            }

            _adapter.SelectCommand = new NpgsqlCommand(selectCmd, _connection);

            _adapter.Fill(_set);

            for(int i = 0; i < _set.Tables.Count; i++)
            {
                _set.Tables[i].TableName = tablesNames[i];
            }

            _connection.Close();
        }
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T? Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public void ExequteQuery(string query, object[] sqlParametersObjects)
        {
            throw new NotImplementedException();
        }
    }
}