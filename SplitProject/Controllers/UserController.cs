using Microsoft.AspNetCore.Mvc;
using SplitProject.DataBase;
using SplitProject.Models;

namespace SplitProject.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("/GetUserById")]
        public ActionResult<User> GetUserById(int id)
        {
            User user = IDbCRUD.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpGet]
        [Route("/NewUser")]
        public async Task NewUser()
        {
            Response.ContentType = "text/html; charset=utf-8";
            string content = @"<form method = 'post'>
                            <label>Name: </label><br />
                            <input name = 'username' /<br /
                            <input type='text' value=''/> </form>";
            await Response.WriteAsync(content);
        }

        [HttpPost("/NewUser")]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            using (SplitContext _db = new())
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return Ok(user);
            }
        }

        [HttpDelete("/DeleteAllUsers")]
        public async Task DeleteAllUsers()
        {
            IDbCRUD.DeleteAllUsers();
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
            if (IDbCRUD.GetUserById(userid) != null)
            {
                IDbCRUD.DeleteUserById(userid);
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