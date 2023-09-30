using System.Collections;
using System.Linq.Expressions;

namespace RGR.Dal.ORM
{
    public class DbSet<TEntity> where TEntity : class, new()
    {
        private List<TEntity> _itemUnchanged = new List<TEntity>();
        private List<TEntity> _itemUdated = new List<TEntity>();
        private List<TEntity> _itemDeleted = new List<TEntity>();
        private List<TEntity> _itemAdded = new List<TEntity>();
        private Expression parametr = Expression.Parameter(typeof(TEntity));
        public List<TEntity> Where(Expression<Func<TEntity, bool>> lambda)
        {

        }
        public void Add(TEntity item)
        {
            _itemAdded.Add(item);
        }
        public void Addrange(IEnumerable<TEntity> items)
        {
            _itemAdded.AddRange(items);
        }
        public int Remove(TEntity item)
        {
            TEntity? itemFromUnchanged = _itemUnchanged.Find(e => e.Equals(item));

            if (itemFromUnchanged == null)
                return 0;

            _itemUnchanged.Remove(itemFromUnchanged);
            _itemDeleted.Add(itemFromUnchanged);
            return 1;
        }
        public TEntity? Find(TEntity item)
        {
            return _itemUdated.Find(e => e.Equals(item));
        }
        public IEnumerable<TEntity> FindAll()
        {
            return _itemUnchanged;
        }
    }
}
