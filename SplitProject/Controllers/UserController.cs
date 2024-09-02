namespace SplitProject.API.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// UserController class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserController"/> class.
/// </remarks>
/// <param name="crudService">CRUD service instance.</param>
/// <param name="dtoService">DTO service instance.</param>
[ApiController]
public class UserController(ICRUDService crudService, IDTOService<User, UserDTO> dtoService) : Controller
{
    private readonly ICRUDService _crudService = crudService;
    private readonly IDTOService<User, UserDTO> _dtoService = dtoService;

    /// <summary>
    /// DELETE all users.
    /// </summary>
    /// <returns>OK if deleted.</returns>
    [HttpDelete("/DeleteAllUsers")]
    public ActionResult DeleteAllUsers()
    {
        _crudService.DeleteAll<User>();
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
        if (_crudService.GetById<User> != null)
        {
            _crudService.DeleteById<User>(id);
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
        var entity = _crudService.GetById<User>(id);
        var user = _dtoService.Map(entity);
        return user;
    }

    /// <summary>
    /// POST create new user.
    /// </summary>
    /// <param name="name">userName.</param>
    /// <returns>OK or badRequest.</returns>
    [HttpPost("/NewUser")]
    public ActionResult NewUser([FromBody] string name)
    {
        _crudService.Add(new User(name));
        return Ok();
    }
}