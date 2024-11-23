namespace BLL.Services;

using System;
using BLL.IServices;
using Domain;
using DTOs;

/// <summary>
/// User DTO service.
/// </summary>
public class UserDTOService : IDTOService<User, UserDTO>
{
    /// <inheritdoc/>
    public UserDTO Map(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new UserDTO(entity.UserID, entity.Balance, entity.Name);
    }

    /// <inheritdoc/>
    public User Map(UserDTO dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        return new User(dto.UserID, dto.Balance, dto.Name);
    }
}