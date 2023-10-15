using Npgsql;

namespace RGR.Dal.Filters
{
    public interface IFilter<TEntity> where TEntity : class, new()
    {
        public string QueryString { get; }
        public List<NpgsqlParameter> Parameters { get; }
    }
}
