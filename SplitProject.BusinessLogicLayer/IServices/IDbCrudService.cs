namespace SplitProject.BLL.IServices;

/// <summary>
/// CRUD <see langword="interface"/>.
/// </summary>
public interface IDbCrudService
{
    /// <summary>
    /// Add Entity to DB.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="entity">entity instance.</param>
    void AddEntity<T>(T entity)
        where T : class;

    /// <summary>
    /// Delete all entities from DB.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    void DeleteAllEntities<T>()
        where T : class;

    /// <summary>
    /// Delete entity from DB by ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    void DeleteEntityById<T>(Guid id)
        where T : class;

    /// <summary>
    /// GET Entity from DB <see langword="by"/> ID.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="id">Entity ID.</param>
    /// <returns>T.</returns>
    T GetEntityById<T>(Guid id)
        where T : class;

    /// <summary>
    /// Save changes.
    /// </summary>
    void SaveChanges();
}