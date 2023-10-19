using RGR.Dal.Repos.BaseRepo;
using RGR.MVC.Views.BaseView;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RGR.MVC.Controlers.BaseControler
{
    public class Controller<TEntity> where TEntity : class, new()
    {
        public IRepo<TEntity> Repo { get; private set; }

        public IView<TEntity> View { get; private set; }

        public Controller(IRepo<TEntity> repo, IView<TEntity> view)
        {
            Repo = repo;
            View = view;
        }

        protected void PrintAllEntities()
        {
            var items = Repo.FindAll();
            View.PrintEntities(items.Item1, items.Item2);
        }

        protected void UpdateEntity(long id, TEntity entity)
        {
            try
            {
                TEntity old = findOldById(id);
                var time = Repo.Update(id, entity);
                View.PrintEntityUpdated(old, entity, time);
            }
            catch (Exception ex)
            {
                View.PrintMissingEntityError(id, ex);
            }
        }

        protected void DeleteEntity(long id)
        {
            try
            {
                TEntity old = findOldById(id);
                var time = Repo.Delete(id);
                View.PrintEntityDeleted(old, time);
            }
            catch (Exception ex)
            {
                View.PrintMissingEntityError(id, ex);
            }
        }

        protected void AddEntity(TEntity entity)
        {
            try
            {
                var time = Repo.Add(entity);
                View.PrintEntityAdded(entity, time);
            }
            catch (Exception ex)
            {
                View.PrintError(ex);
            }
        }

        protected TEntity findOldById(long id)
        {
            var a = typeof(TEntity).GetProperties().Where(p => p.GetCustomAttributes<KeyAttribute>() != null).First();
            return Repo.FindAll().Item1.Where(e => (long?)a.GetValue(e) == id
            ).First();
        }
    }
}
