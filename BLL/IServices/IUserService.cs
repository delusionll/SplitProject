namespace BLL.IServices;

using System;
using System.Threading.Tasks;
using DTOs;

public interface IUserService
{
    /// <summary>
    /// Add new User by Name.
    /// </summary>
    /// <param name="name">user name.</param>
    /// <returns></returns>
    ValueTask<UserDTO?> AddAsync(string name);

    /// <summary>
    /// Delete all user entities.
    /// </summary>
    /// <returns>task.</returns>
    ValueTask DeleteAllAsync();

    /// <summary>
    /// delete user by id.
    /// </summary>
    /// <param name="id">user id.</param>
    /// <returns></returns>
    ValueTask DeleteByIdAsync(Guid id);

    /// <summary>
    /// get user by id.
    /// </summary>
    /// <param name="id">user id.</param>
    /// <returns></returns>
    ValueTask<UserDTO?> GetByIdAsync(Guid id);
}