using ex01.Dto;
using ex01.Models;
using ex01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
namespace ex01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service = new();

        //GetUsers
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_service.GetUsers());
        }

        //CreateUser
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            return Ok(_service.CreateUser(userDto));

        }


    }
}
