namespace RGR.MVC.Views.BaseView
{
    public interface IView<TEntity> where TEntity: class, new()
    {
        public void PrintMissingEntityError(long id, Exception exception);

        public void PrintEntityAdded(TEntity entity, string query);

        public void PrintEntityUpdated(TEntity oldEntity, TEntity newEntity, string query);

        public void PrintEntityDeleted(TEntity entity, string query);

        public void PrintEntities(IEnumerable<TEntity> entities, string query);

        public void PrintError(Exception exception);

        public void PrintGenerated(long count);
    }
}
