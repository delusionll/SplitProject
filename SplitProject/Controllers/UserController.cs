namespace SplitProject.API.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// UserController class.
/// </summary>
[ApiController]
public class UserController : Controller
{
    private readonly IDbCrudService _dbCrudService;

    private readonly IDtoService<User, UserDTO> _dtoService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="dbCrudService">CRUD service instance.</param>
    /// <param name="dtoService">DTO service instance.</param>
    public UserController(IDbCrudService dbCrudService, IDtoService<User, UserDTO> dtoService)
    {
        _dbCrudService = dbCrudService;
        _dtoService = dtoService;
    }

    /// <summary>
    /// DELETE all users.
    /// </summary>
    /// <returns>OK if deleted.</returns>
    [HttpDelete("/DeleteAllUsers")]
    public ActionResult DeleteAllUsers()
    {
        _dbCrudService.DeleteAllEntities<User>();
        return Ok();
    }

    /// <summary>
    /// DELETE user by ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns>OK.</returns>
    [HttpDelete("/DeleteUserById")]
    public ActionResult DeleteUserById(Guid id)
    {
        if (_dbCrudService.GetEntityById<User> != null)
        {
            _dbCrudService.DeleteEntityById<User>(id);
            return Ok();
        }

        return BadRequest();
    }

    /// <summary>
    /// GET userDTO by ID.
    /// </summary>
    /// <param name="id">userID.</param>
    /// <returns>OK.</returns>
    [HttpGet("/GetUserById")]
    public UserDTO GetUserById(Guid id)
    {
        var entity = _dbCrudService.GetEntityById<User>(id);
        var user = _dtoService.ToDto(entity);
        return user;
    }

    /// <summary>
    /// POST create new user.
    /// </summary>
    /// <param name="name">userName.</param>
    /// <returns>OK or badRequest.</returns>
    [HttpPost("/NewUser")]
    public ActionResult NewUser(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest();
        }

        var newuser = _dtoService.ToEntity(new UserDTO { Name = name });
        _dbCrudService.AddEntity(newuser);
        return Ok();
    }
}