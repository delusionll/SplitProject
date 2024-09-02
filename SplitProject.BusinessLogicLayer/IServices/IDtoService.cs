namespace SplitProject.BLL.IServices;

/// <summary>
/// Service to transform to and from DTO.
/// </summary>
/// <typeparam name="TE">Entity type.</typeparam>
/// <typeparam name="TD">DTO type.</typeparam>
public interface IDTOService<TE, TD>
{
    /// <summary>
    /// transform from entity to DTO.
    /// </summary>
    /// <param name="entity">entity instance.</param>
    /// <returns>DTO instance.</returns>
    TD Map(TE entity);

    /// <summary>
    /// transform from DTO to entity.
    /// </summary>
    /// <param name="dto">dtp instance.</param>
    /// <returns>Entity instance.</returns>
    TE Map(TD dto);
}