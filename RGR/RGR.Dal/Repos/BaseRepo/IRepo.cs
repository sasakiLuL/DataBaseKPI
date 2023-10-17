using RGR.Dal.Filters;
using System.Reflection;

namespace RGR.Dal.Repos.BaseRepo
{
    public interface IRepo<TEntity> where TEntity : class, new()
    {
        string Key { get; }

        List<string> Columns { get; }

        string TableName { get; }

        void Add(TEntity entity);

        void Delete(long id);

        void Update(long id, TEntity entity);

        IEnumerable<TEntity> Find(Filter<TEntity> filter);

        IEnumerable<TEntity> FindAll();
    }
}
