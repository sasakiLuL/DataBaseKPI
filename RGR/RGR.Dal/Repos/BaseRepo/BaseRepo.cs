using Npgsql;

namespace RGR.Dal.Repos.BaseRepo
{
    public abstract class BaseRepo<T>
    {
        protected NpgsqlConnection Connection { get; private set; }
        public BaseRepo(NpgsqlConnection connection)
        {
            Connection = connection;
        }
    }
}
