using Npgsql;
using System.Data;

namespace RGR.Dal.Repos.Base
{
    public abstract class BaseRepo<T> : IRepo<T> where T : new()
    {
        protected NpgsqlConnection _connection;
        protected BaseRepo(Contex contex)
        {
            _connection = connection;
        }
        public int Add(T entity)
        {
            _connection.Open();

            using var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;

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