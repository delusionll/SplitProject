namespace SplitProject.BLL.Services;

using System;
using SplitProject.BLL.IServices;
using SplitProject.DAL;

/// <summary>
/// Service to operate with DB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CRUDService"/> class.
/// </remarks>
/// <param name="dbContext">DB context.</param>
public class CRUDService(SplitContext dbContext) : ICRUDService
{
    private readonly SplitContext _context = dbContext;

    /// <inheritdoc/>
    public void Add<T>(T entity)
        where T : class
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void DeleteAll<T>()
        where T : class
    {
        foreach (var e in _context.Set<T>())
        {
            _context.Set<T>().Remove(e);
        }

        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void DeleteById<T>(Guid id)
        where T : class
    {
        _context.Set<T>().Remove(GetById<T>(id));
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public T GetById<T>(Guid id)
        where T : class
    {
        if (id != Guid.Empty)
        {
            var entity = _context.Set<T>().Find(id);
            return entity != null ? entity : throw new ArgumentException("Wrong Id");
        }

        throw new ArgumentException("Wrong Id");
    }

    /// <inheritdoc/>
    public void SaveChanges() => _context.SaveChanges();
}