using ex01.Dto;
using ex01.Models;

namespace ex01.Repositories
{
    public interface IProductRepository
    {
        List<ProductDto> createProducts(List<CreateProductDto> products);
        ProductDto deleteProduct(int id);
        List<ProductDto> GetProductByCategory(string ca = "");
        ProductDto GetProductById(int id);
        List<ProductDto> GetProductOrderByName();
        List<ProductDto> GetProducts();
        List<ProductWithCategoriesDto> GetProductWithCategories();
        List<ProductDto> PaginationProducts(int page = 1, int size = 5);
        List<ProductDto> productNotDeleted();
        ProductDto UpdateProduct(int id, Product p);
    }
}