namespace BLL.IServices;

using System;
using System.Threading.Tasks;

/// <summary>
/// CRUD <see langword="interface"/>.
/// </summary>
public interface ICRUDService
{
    /// <summary>
    /// Add Entity to DB.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="entity">entity instance.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task AddAsync<T>(T entity)
        where T : class;

    /// <summary>
    /// Delete all entities from DB.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task DeleteAllAsync<T>()
        where T : class;

    /// <summary>
    /// Delete entity from DB by ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task DeleteByIdAsync<T>(Guid id)
        where T : class;

    /// <summary>
    /// GET Entity from DB <see langword="by"/> ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    /// <returns>T.</returns>
    Task<T> GetByIdAsync<T>(Guid id)
        where T : class;

    /// <summary>
    /// Save changes.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task SaveChangesAsync();
}