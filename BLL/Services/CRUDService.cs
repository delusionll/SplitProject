namespace BLL.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> AddAsync<T>(T entity)
        where T : class
    {
        await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return new OkResult();
    }

    /// <inheritdoc/>
    public async Task<IActionResult> DeleteAllAsync<T>()
        where T : class
    {
        var entities = await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return new OkResult();
    }

    /// <inheritdoc/>
    public async Task<IActionResult> DeleteByIdAsync<T>(Guid id)
        where T : class
    {
        var entity = await GetByIdAsync<T>(id).ConfigureAwait(false);
        if (entity == null)
            return new NotFoundResult();

        _context.Set<T>().Remove(entity.Value);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return new OkResult();
    }

    /// <inheritdoc/>
    public async Task<ActionResult<IEnumerable<T>>> GetAllAsync<T>()
        where T : class
    {
        var entities = await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        return entities == null || entities.Count == 0 ? (ActionResult<IEnumerable<T>>)new NotFoundResult() : (ActionResult<IEnumerable<T>>)new OkObjectResult(entities);
    }

    /// <inheritdoc/>
    public async Task<ActionResult<T>> GetByIdAsync<T>(Guid id)
        where T : class
    {
        if (id != Guid.Empty)
        {
            var entity = await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
            return entity != null ? new ActionResult<T>(entity) : new NotFoundResult();
        }

        return new NotFoundResult();
    }

    /// <inheritdoc/>
    public async Task<ActionResult<int>> SaveChangesAsync()
    {
        try
        {
            var res = await _context.SaveChangesAsync().ConfigureAwait(false);
            return new OkObjectResult(res);
        }
        catch (DbUpdateException ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

    /// <inheritdoc/>
    public async Task<ActionResult<TE>> UpdateByIdAsync<TE, TP>(Guid id, TP property)
        where TE : class
    {
        var entity = await _context.Set<TE>().FindAsync(id).ConfigureAwait(false);

        if (entity == null)
        {
            return new NotFoundResult();
        }

        var propertyInfo = typeof(TE).GetProperty(typeof(TP).Name);
        if (propertyInfo == null || !propertyInfo.CanWrite)
        {
            return new BadRequestResult();
        }

        propertyInfo.SetValue(entity, property);

        await _context.SaveChangesAsync().ConfigureAwait(false);

        return new OkObjectResult(entity);
    }
}