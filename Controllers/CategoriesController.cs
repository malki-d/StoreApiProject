using ex01.Dto;
using ex01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ex01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service  ;
        public CategoriesController(ICategoryService service)
        {
            _service=service;
        }

        //GetCategories
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_service.GetCategories());
        }

        //CreateCategory
        [HttpPost]
        public IActionResult CreateCategory([FromBody] string name)
        {
            return Ok(_service.CreateCategory(name));

        }
    }
}
