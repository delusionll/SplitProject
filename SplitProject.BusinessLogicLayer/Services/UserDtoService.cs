namespace SplitProject.BLL.Services;

using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// User DTO service.
/// </summary>
public class UserDTOService : IDTOService<User, UserDTO>
{
    /// <inheritdoc/>
    public UserDTO Map(User entity) => new UserDTO(entity.UserID, entity.Balance, entity.Name);

    /// <inheritdoc/>
    public User Map(UserDTO dto) => new User(dto.UserID, dto.Balance, dto.Name);
}