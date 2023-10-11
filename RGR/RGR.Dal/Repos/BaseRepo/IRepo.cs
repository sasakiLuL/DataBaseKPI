namespace RGR.Dal.Repos.BaseRepo
{
    public interface IRepo<T> where T : class, new()
    {
        void Add(T entity);

        void Delete(int id);

        void Update(int id, T entity);

        IEnumerable<T> FindAll();
    }
}
