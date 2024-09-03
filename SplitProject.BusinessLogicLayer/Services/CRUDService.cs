namespace BLL.Services;

using System;
using System.Threading.Tasks;
using BLL.IServices;
using DAL;
using Microsoft.EntityFrameworkCore;

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
    public async Task AddAsync<T>(T entity)
        where T : class
    {
        await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteAllAsync<T>()
        where T : class
    {
        var entities = await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteByIdAsync<T>(Guid id)
        where T : class
    {
        var entity = await GetByIdAsync<T>(id).ConfigureAwait(false);
        if (entity == null)
            throw new ArgumentException($"entity with id {id} not found.");

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<T> GetByIdAsync<T>(Guid id)
        where T : class
    {
        if (id != Guid.Empty)
        {
            var entity = await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
            return entity != null ? entity : throw new ArgumentException("Wrong Id");
        }

        throw new ArgumentException("Wrong Id");
    }

    /// <inheritdoc/>
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}