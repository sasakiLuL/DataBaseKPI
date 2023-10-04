using RGR.Dal.Filters;
using System.Linq.Expressions;

namespace RGR.Dal
{
    public interface IQuery<TEntity>
    {
        IQuery<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        IQuery<TEntity> Where<TFilter>(Expression<Func<TEntity, TFilter>> predicate) where TFilter : IFilter;
        IQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> predicate);
        IEnumerable<TEntity> Execute();
        void ExecuteNoQuery();
    }
}
