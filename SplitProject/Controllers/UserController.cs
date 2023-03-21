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
            User entity = _dbCrudService.GetUserById(id);
            UserDTO user = _dtoService.ToDto(entity);
            return user;
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

        [HttpPost("/NewUser")]
        public ActionResult NewUser(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            User newuser = _dtoService.ToEntity(new UserDTO() { UserName = name });
            _dbCrudService.AddUser(newuser);
            return Ok();
        }

        [HttpDelete("/DeleteAllUsers")]
        public async Task DeleteAllUsers()
        {
            IDbCrudService.DeleteAllUsers();
            await Response.WriteAsync("All users are deleted.");
        }

        [HttpGet("/DeleteUserById")]
        public async Task DeleteUserById()
        {
            Response.ContentType = "text/html; charset=utf-8";
            string content = @"<form method = 'post'>
                            <label>UserId: </label><br />
                            <input name = 'userid' /<br /
                            <input type='number' value='Enter User ID (int)'/> </form>";
            await Response.WriteAsync(content);
        }

        [HttpDelete("/DeleteUserById")]
        public string DeleteUserById([FromForm] int userid)
        {
            if (IDbCrudService.GetUserById(userid) != null)
            {
                IDbCrudService.DeleteUserById(userid);
                return $"User with {userid} id removed from DB";
            }
            else
            {
                return "User not found";
            }
        }

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