namespace BLL.IServices;

using System;
using System.Threading.Tasks;
using DTOs;

public interface IUserService
{
    /// <summary>
    /// Delete all user entities.
    /// </summary>
    /// <returns>task.</returns>
    ValueTask DeleteAllAsync();

    /// <summary>
    /// get user by id.
    /// </summary>
    /// <param name="id">user id.</param>
    /// <returns></returns>
    ValueTask<UserDTO?> GetByIdAsync(Guid id);

    /// <summary>
    /// delete user by id.
    /// </summary>
    /// <param name="id">user id.</param>
    /// <returns></returns>
    ValueTask DeleteByIdAsync(Guid id);

    /// <summary>
    /// Add new User by Name.
    /// </summary>
    /// <param name="name">user name.</param>
    /// <returns></returns>
    ValueTask<UserDTO?> AddAsync(string name);
}