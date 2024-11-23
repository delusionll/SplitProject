namespace DAL;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

/// <summary>
/// Service to operate with DB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the
/// <see cref="Repository"/> class.
/// </remarks>
/// <param name="dbContext">DB context.</param>
public class Repository(SplitContext dbContext) : IRepository
{
    private readonly DbContext _context = dbContext;

    /// <inheritdoc/>
    public async ValueTask<EntityEntry<T>?> AddAsync<T>(
        T entity)
        where T : class
    {
        try
        {
            var res = await _context.Set<T>()
                .AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return res;
        }
        catch (Exception ex)
        {
            // TODO LOG
            Debug.WriteLine(DateTime.Now + ex.Message);
            return null;
        }
    }

    /// <inheritdoc/>
    public async ValueTask<int> DeleteAllAsync<T>()
        where T : class
    {
        try
        {
            _context.Set<T>().RemoveRange(
                await _context.Set<T>().ToArrayAsync().ConfigureAwait(false));
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // TODO LOG
            Debug.WriteLine(DateTime.Now + ex.Message);
            return 0;
        }
    }

    /// <inheritdoc/>
    public async ValueTask<EntityEntry<T>?> DeleteByIdAsync<T>(
        Guid id)
        where T : class
    {
        var entity = await GetByIdAsync<T>(id).ConfigureAwait(false);
        if (entity == null)
        {
            return null;
        }

        var res = _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return res;
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<T> GetAll<T>()
        where T : class => _context.Set<T>().AsAsyncEnumerable();

    /// <inheritdoc/>
    public async ValueTask<T?> GetByIdAsync<T>(Guid id)
        where T : class
    {
        if (id != Guid.Empty)
        {
            var entity = await _context.Set<T>()
                .FindAsync(id).ConfigureAwait(false);
            return entity != null ? entity : null;
        }

        return null;
    }

    /// <inheritdoc/>
    public async ValueTask<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        catch (DbUpdateException ex)
        {
            Debug.WriteLine(DateTime.Now + ex.Message);
            return 0;
        }
    }
}