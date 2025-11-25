using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using ex01.Models;
using ex01.Services;
using ex01.Dto;
namespace ex01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductService _productService = new();

        //GetProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        //GetProductById
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {

            return Ok(_productService.GetProductById(id));

        }

        //GetProductsByCategory
        [HttpGet]
        [Route("GetProductsByCategory")]
        public IActionResult GetProductsByCategory(string c)
        {
            return Ok(_productService.GetProductByCategory(c));
        }

        //GetProductOrderByName
        [HttpGet]
        [Route("GetProductOrderByName")]
        public IActionResult GetProductOrderByName()
        {
            return Ok(_productService.GetProductOrderByName());
        }


        //GetProductWithCategories
        [HttpGet]
        [Route("GetProductWithCategories")]
        public IActionResult GetProductWithCategories()
        {
            return Ok(_productService.GetProductWithCategories());
        }


        //deleteProduct
        [HttpDelete]
        public IActionResult deleteProduct(int id)
        {
            return Ok(_productService.deleteProduct(id));
        }


        //productNotDeleted
        [HttpGet]
        [Route("productNotDeleted")]
        public IActionResult productNotDeleted()
        {
            return Ok(_productService.productNotDeleted());
        }


        //CreateProducts
        [HttpPost]
        [Route("CreateProducts")]
        public IActionResult CreateProducts([FromBody] List<CreateProductDto> prod)
        {
            try
            {
                return Ok(_productService.createProducts(prod));

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //UpdateProduct
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product p)
        {
            return Ok(_productService.UpdateProduct(id, p));
        }

        //PaginationProducts
        [HttpGet]
        [Route("PaginationProducts")]
        public IActionResult PaginationProducts([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var result = new
            {
                Data = _productService.PaginationProducts(page, size),
                CurrentPage = page,
                PageSize = size,
                TotalItems = _productService.GetProducts().Count()
            };
            return Ok(result);
        }

    }

}
