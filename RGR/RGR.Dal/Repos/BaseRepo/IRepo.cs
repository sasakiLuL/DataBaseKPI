namespace RGR.Dal.Repos.BaseRepo
{
    public interface IRepo<T> where T : class, new()
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(int id);
        void Update(int id, T entity);
        void Find(int id);
        IEnumerable<T> FindAll();
    }
}
