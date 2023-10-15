using RGR.Dal.Filters;

namespace RGR.Dal.Repos.BaseRepo
{
    public interface IRepo<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);

        void Delete(int id);

        void Update(int id, TEntity entity);

        IEnumerable<TEntity> Find(Filter<TEntity> filter);

        IEnumerable<TEntity> FindAll();
    }
}
