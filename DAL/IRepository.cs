namespace DAL;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

/// <summary>
/// CRUD <see langword="interface"/>.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Add Entity to DB.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="entity">entity instance.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    ValueTask<EntityEntry<T>?> AddAsync<T>(T entity)
        where T : class;

    /// <summary>
    /// Delete all entities from DB.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    ValueTask DeleteAllAsync<T>()
        where T : class;

    /// <summary>
    /// Delete entity from DB by ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    ValueTask<EntityEntry<T>?> DeleteByIdAsync<T>(Guid id)
        where T : class;

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <returns>IEnumerable of T.</returns>
    IAsyncEnumerable<T> GetAll<T>()
        where T : class;

    /// <summary>
    /// GET Entity from DB <see langword="by"/> ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    /// <returns>T.</returns>
    T? GetById<T>(Guid id)
        where T : class;

    /// <summary>
    /// GET Entity from DB <see langword="by"/> ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    /// <returns>T.</returns>
    ValueTask<T?> GetByIdAsync<T>(Guid id)
        where T : class;

    /// <summary>
    /// Save changes.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> represents save operation. Task
    /// result contains the number of entities saved.
    /// </returns>
    ValueTask<int> SaveChangesAsync();
}