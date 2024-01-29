namespace SplitProject.BLL.Services;

using DAL;
using IServices;

public class DbCrudService : IDbCrudService
{
    private readonly SplitContext _context;

    public DbCrudService(SplitContext context)
    {
        _context = context;
    }

    public void AddEntity<T>(T entity) where T : class
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void DeleteAllEntityes<T>() where T : class
    {
        foreach (var e in _context.Set<T>()) _context.Set<T>().Remove(e);
        _context.SaveChanges();
    }

    public void DeleteEntityById<T>(Guid Id) where T : class
    {
        _context.Set<T>().Remove(GetEntityById<T>(Id));
        _context.SaveChanges();
    }

    public T GetEntityById<T>(Guid Id) where T : class
    {
        if (Id != Guid.Empty)
        {
            var entity = _context.Set<T>().Find(Id);
            if (entity != null)
            {
                return entity;
            }

            throw new ArgumentException("Wrong Id");
        }

        throw new ArgumentException("Wrong Id");
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}