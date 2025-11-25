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
        public List<Product> productsList = new List<Product>()
        {
            new Product(){Id="1",Name="bag",Price=123,Desc="aaaaaaaaa"},
            new Product(){Id="2",Name="mirror",Price=50,Desc="bbbbbbbbbb"},
            new Product(){Id="3",Name="mirror",Price=50,Desc="bbbbbbbbbb"},
            new Product(){Id="4",Name="mirror",Price=50,Desc="bbbbbbbbbb"},
            new Product(){Id="5",Name="mirror",Price=50,Desc="bbbbbbbbbb"},
            new Product(){Id="6",Name="mirror",Price=50,Desc="bbbbbbbbbb"}
        };

        private readonly ProductService _productService = new();

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsList);
        }

        [HttpGet]
        [Route("GetProductsByCategory")]
        public IActionResult GetProductsByCategory(string c)
        {
            return Ok(_productService.GetProductByCategory(c));
        }
        [HttpGet]
        [Route("GetProductOrderByName")]
        public IActionResult GetProductOrderByName()
        {
            return Ok(_productService.GetProductOrderByName());
        }
        [HttpGet]
        [Route("GetProductWithCategories")]
        public IActionResult GetProductWithCategories()
        {
            return Ok(_productService.GetProductWithCategories());
        }
        [HttpGet]
        [Route("productNotDeleted")]
        public IActionResult productNotDeleted()
        {
            return Ok(_productService.productNotDeleted());
        }
        [HttpGet]
        [Route("bags")]
        public IActionResult bags()
        {
            return Ok(_productService.bags());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            Product? prod = productsList.Find(x => x.Id == id);
            if (prod != null)
            {
                return Ok(prod);
            }
            else return Ok("not found");
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] List<CreateProductDto> prod)
        { try
            {
                _productService.createProducts(prod);
                return Ok(productsList);
            }

            catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

        }
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
        //[HttpPut("{id}")]
        //public IActionResult Put(string id, [FromBody] Product p)
        //{
        //    Product? prod = productsList.Find(x => x.id == id);
        //    if (prod != null)
        //    {
        //        prod.name = p.name;
        //        prod.price = p.price;
        //        prod.imageUrl = p.imageUrl;
        //        prod.desc = p.desc;
        //        prod.categories = p.categories;
        //        prod.colors = p.colors;
        //        prod.sale = p.sale;

        //        return Ok(prod);
        //    }
        //    else
        //        return Ok("not found");
        //}

        [HttpGet]
        [Route("GetPermitRequests")]
        public IActionResult GetPermitRequests([FromQuery] int page = 1, [FromQuery] int size = 5)
        {

            var pageData = productsList
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();
            var result = new
            {
                Data = pageData,
                CurrentPage = page,
                PageSize = size,
                TotalItems = productsList.Count
            };
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult deleteProduct(string id)
        {
            return Ok(_productService.deleteProduct(id));
        }
        //[HttpPost("CreateCategoryWithProc")]
        //public IActionResult CreateCategoryWithProc(string name)
        //{
        //    return Ok(_productService.CreateCategoryWithProc(name));
        //}
    }

}
