using RGR.Dal.Filters;
using System.Reflection;

namespace RGR.Dal.Repos.BaseRepo
{
    public interface IRepo<TEntity> where TEntity : class, new()
    {
        string Key { get; }

        List<string> Columns { get; }

        string TableName { get; }

        string Add(TEntity entity);

        string Delete(long id);

        string Update(long id, TEntity entity);

        (IEnumerable<TEntity>, string) Find(Filter<TEntity> filter);

        (IEnumerable<TEntity>, string) FindAll();

        public void Generate(long count);
    }
}
