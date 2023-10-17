namespace RGR.MVC.Views.BaseView
{
    public interface IView<TEntity> where TEntity: class, new()
    {
        public void PrintMissingEntityError(long id, Exception exception);

        public void PrintEntityAdded(TEntity entity);

        public void PrintEntityUpdated(TEntity oldEntity, TEntity newEntity);

        public void PrintEntityDeleted(TEntity entity);

        public void PrintEntities(IEnumerable<TEntity> entities);
    }
}
