using System.Linq.Expressions;

namespace RGR.Dal
{
    public interface IQuery<TEntity>
    {
        IQuery<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> predicate);
        IEnumerable<TEntity> Execute();
        void ExecuteNoQuery();
    }
}
