namespace RGR.MVC.Views.BaseView
{
    public interface IView<TEntity> where TEntity: class, new()
    {
        public void Print();
    }
}
