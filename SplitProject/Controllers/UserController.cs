using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IDbCrudService _dbCrudService;
        private readonly IDtoService<User, UserDTO> _dtoService;
        public UserController(IDbCrudService dbCrudService, IDtoService<User, UserDTO> dtoService)
        {
            _dbCrudService = dbCrudService;
            _dtoService = dtoService;
        }

        [HttpGet("/GetUserById")]
        public UserDTO GetUserById(Guid id)
        {
            User entity = _dbCrudService.GetEntityById<User>(id);
            UserDTO user = _dtoService.ToDto(entity);
            return user;
        }


        [HttpPost("/NewUser")]
        public ActionResult NewUser(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            User newuser = _dtoService.ToEntity(new UserDTO() { Name = name });
            _dbCrudService.AddEntity<User>(newuser);
            return Ok();
        }

        [HttpDelete("/DeleteAllUsers")]
        public ActionResult DeleteAllUsers()
        {
            _dbCrudService.DeleteAllEntityes<User>();
            return Ok();
        }


        [HttpDelete("/DeleteUserById")]
        public ActionResult DeleteUserById(Guid Id)
        {
            if (_dbCrudService.GetEntityById<User> != null)
            {
                _dbCrudService.DeleteEntityById<User>(Id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet]
        //[Route("/NewUser")]
        //public async Task NewUser()
        //{
        //    Response.ContentType = "text/html; charset=utf-8";
        //    string content = @"<form method = 'post'>
        //                    <label>Name: </label><br />
        //                    <input name = 'username' /<br /
        //                    <input type='text' value=''/> </form>";
        //    await Response.WriteAsync(content);
        //}


        //[HttpGet("/DeleteUserById")]
        //public async Task DeleteUserById()
        //{
        //    Response.ContentType = "text/html; charset=utf-8";
        //    string content = @"<form method = 'post'>
        //                    <label>UserId: </label><br />
        //                    <input name = 'userid' /<br /
        //                    <input type='number' value='Enter User ID (int)'/> </form>";
        //    await Response.WriteAsync(content);
        //}

        //[HttpGet("/GetUserById")]
        //public async Task GetUserById()
        //{
        //    Response.ContentType = "text/html; charset=utf-8";
        //    string content = @"<form method = 'get'>
        //                    <label>Id: </label><br />
        //                    <input name = 'id' /<br /
        //                    <input type='number' value=''/> </form>";
        //    await Response.WriteAsync(content);
        //}
    }
}