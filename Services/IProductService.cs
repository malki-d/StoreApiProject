using ex01.Dto;
using ex01.Models;

namespace ex01.Services
{
    public interface IProductService
    {
        List<ProductDto> createProducts(List<CreateProductDto> p);
        ProductDto deleteProduct(int id);
        List<ProductDto> GetProductByCategory(string c);
        ProductDto GetProductById(int id);
        List<ProductDto> GetProductOrderByName();
        List<ProductDto> GetProducts();
        List<ProductWithCategoriesDto> GetProductWithCategories();
        List<ProductDto> PaginationProducts(int page = 1, int size = 5);
        List<ProductDto> productNotDeleted();
        ProductDto UpdateProduct(int id, Product p);
    }
}