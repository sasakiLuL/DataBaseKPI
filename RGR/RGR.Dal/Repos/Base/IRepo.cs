namespace RGR.Dal.Repos.Base
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int AddRange(IEnumerable<T> entities);
        int Update(T entity);
        int UpdateRange(IEnumerable<T> entities);
        int Delete(T entity);
        int Delete(int id);
        int DeleteRange(IEnumerable<T> entities);
        T? Find(int? id);
        IEnumerable<T> FindAll();
        void ExequteQuery(string query, object[] sqlParametersObjects);
    }
}
