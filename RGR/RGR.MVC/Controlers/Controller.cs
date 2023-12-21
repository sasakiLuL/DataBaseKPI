using RGR.Dal;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers;

public class Controller<TEntity> where TEntity : class, new()
{
    private readonly Lab2Context _context;

    public Controller(Lab2Context context)
    {
        _context = context;
    }

    public void PrintAllEntities()
    {
        var items = _context.Set<TEntity>();
        View.PrintEntities(items);
    }

    public void UpdateEntity(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            View.PrintEntityUpdated(entity);
        }
        catch (Exception ex)
        {
            View.PrintError(ex);
        }
    }

    public void DeleteEntity(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            View.PrintEntityDeleted(entity);
        }
        catch (Exception ex)
        {
            View.PrintError(ex);
        }
    }

    public void AddEntity(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            View.PrintEntityAdded(entity);
        }
        catch (Exception ex)
        {
            View.PrintError(ex);
        }
    }
}
