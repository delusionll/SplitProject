﻿namespace BLL.Services;

using BLL.DTO;
using BLL.IServices;
using Domain.Models;

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