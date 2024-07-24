namespace SplitProject.BLL.Services;

using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// User DTO service.
/// </summary>
public class UserDtoService : IDtoService<User, UserDTO>
{
    /// <inheritdoc/>
    public UserDTO ToDto(User entity)
    {
        return new UserDTO
        {
            Balance = entity.Balance,
            Name = entity.Name,
        };
    }

    /// <inheritdoc/>
    public User ToEntity(UserDTO dto)
    {
        User entity = new()
        {
            Name = dto.Name,
            Balance = dto.Balance,
        };
        return entity;
    }
}