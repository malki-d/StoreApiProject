using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using ex01.Models;
namespace ex01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public List<User> usersList = new List<User>()
        {
            //new User(){name="aaa",id="111111111",email="aaaaaaaaa@gma"},
            //new User(){name="bbbb",id="22222222222",email="bbbbbbbb@gma"}
        };


        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(usersList);
        }

    
    }
}
