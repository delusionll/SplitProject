namespace SplitProject.BLL.Services;

using System;
using SplitProject.BLL.IServices;
using SplitProject.DAL;

/// <summary>
/// Service to operate with DB.
/// </summary>
public class CRUDService : IDbCrudService
{
    private readonly SplitContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CRUDService"/> class.
    /// </summary>
    /// <param name="context">DB context.</param>
    public CRUDService(SplitContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public void AddEntity<T>(T entity)
        where T : class
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void DeleteAllEntities<T>()
        where T : class
    {
        foreach (var e in _context.Set<T>())
        {
            _context.Set<T>().Remove(e);
        }

        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void DeleteEntityById<T>(Guid id)
        where T : class
    {
        _context.Set<T>().Remove(GetEntityById<T>(id));
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public T GetEntityById<T>(Guid id)
        where T : class
    {
        if (id != Guid.Empty)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                return entity;
            }

            throw new ArgumentException("Wrong Id");
        }

        throw new ArgumentException("Wrong Id");
    }

    /// <inheritdoc/>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}