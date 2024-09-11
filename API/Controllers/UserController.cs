namespace API.Controllers;

using System;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/// <summary>
/// UserController class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserController"/> class.
/// </remarks>
/// <param name="crudService">CRUD service instance.</param>
/// <param name="dtoService">DTO service instance.</param>
[ApiController]
public class UserController(ICRUDService crudService,
                            IDTOService<User, UserDTO> dtoService,
                            ILogger<UserController> logger) : Controller
{
    private readonly ICRUDService _crudService = crudService;
    private readonly IDTOService<User, UserDTO> _dtoService = dtoService;
    private readonly ILogger<UserController> _logger = logger;

    /// <summary>
    /// DELETE all users.
    /// </summary>
    /// <returns>OK if deleted.</returns>
    [HttpDelete("/DeleteAllUsers")]
    public async Task<ActionResult> DeleteAllUsers()
    {
        await _crudService.DeleteAllAsync<User>().ConfigureAwait(false);
        return Ok();
    }

    /// <summary>
    /// DELETE user by ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns>OK.</returns>
    [HttpDelete("/DeleteUserById")]
    public async Task<ActionResult> DeleteUserByIdAsync(Guid id)
    {
        var user = await _crudService.GetByIdAsync<User>(id).ConfigureAwait(false);
        if (user != null)
        {
            await _crudService.DeleteByIdAsync<User>(id).ConfigureAwait(false);
            if (user.Value == null)
                return BadRequest();
            return Ok(_dtoService.Map(user.Value));
        }

        return NotFound();
    }

    /// <summary>
    /// GET userDTO by ID.
    /// </summary>
    /// <param name="id">userID.</param>
    /// <returns>OK.</returns>
    [HttpGet("/GetUserById")]
    public async Task<ActionResult<UserDTO>> GetUserByIdAsync(Guid id)
    {
        var entity = await _crudService.GetByIdAsync<User>(id).ConfigureAwait(false);

        if (entity.Value == null)
            return NotFound();

        var userDTO = _dtoService.Map(entity.Value);
        return Ok(userDTO);
    }

    /// <summary>
    /// POST create new user.
    /// </summary>
    /// <param name="name">userName.</param>
    /// <returns>OK or badRequest.</returns>
    [HttpPost("/NewUser")]
    public async Task<ActionResult> NewUserAsync([FromBody] string name)
    {
        var newUser = new User(name);
        var result = await _crudService.AddAsync(newUser).ConfigureAwait(false);
        _logger.LogInformation(DateTime.Now.ToString(), name);
        if (result == null)
            return BadRequest();
        return Ok(newUser);
    }
}