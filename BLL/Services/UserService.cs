namespace BLL.Services;

using System;
using System.Threading.Tasks;
using BLL.IServices;
using DAL;
using Domain;
using DTOs;

/// <summary>
/// Service to work with users.
/// </summary>
/// <param name="repository">repository instance.</param>
/// <param name="dtoService">dto service instance.</param>
public class UserService(IRepository repository, IDTOService<User, UserDTO> dtoService) : IUserService
{
    private readonly IDTOService<User, UserDTO> _dtoService = dtoService;
    private readonly IRepository _repository = repository;

    /// <inheritdoc/>
    public async ValueTask<UserDTO?> AddAsync(string name)
    {
        var res = await _repository.AddAsync(new User(name)).ConfigureAwait(false);
        return res == null ? null : _dtoService.Map(res.Entity);
    }

    /// <inheritdoc/>
    public async ValueTask DeleteAllAsync()
    {
        await _repository.DeleteAllAsync<User>().ConfigureAwait(false);
        await _repository.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async ValueTask DeleteByIdAsync(Guid id)
    {
        await _repository.DeleteByIdAsync<User>(id).ConfigureAwait(false);
        await _repository.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async ValueTask<UserDTO?> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync<User>(id).ConfigureAwait(false);
        return user == null ? null : _dtoService.Map(user);
    }
}