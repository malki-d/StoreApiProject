using ex01.Dto;
using ex01.Models;
using ex01.Repositories;

namespace ex01.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository ;
        public ProductService(IProductRepository repository)
        {
            _repository=repository;
        }

        //GetProducts
        public List<ProductDto> GetProducts()
        {
            return _repository.GetProducts();
        }

        //GetProductById
        public ProductDto GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        //UpdateProduct
        public ProductDto UpdateProduct(int id, Product p)
        {
            return _repository.UpdateProduct(id, p);
        }

        //GetProductByCategory
        public List<ProductDto> GetProductByCategory(string c)
        {
            return _repository.GetProductByCategory(c);
        }

        //GetProductOrderByName
        public List<ProductDto> GetProductOrderByName()
        {
            return _repository.GetProductOrderByName();
        }

        //GetProductWithCategories
        public List<ProductWithCategoriesDto> GetProductWithCategories()
        {
            return _repository.GetProductWithCategories();
        }

        //deleteProduct
        public ProductDto deleteProduct(int id)
        {
            return _repository.deleteProduct(id);
        }


        //productNotDeleted
        public List<ProductDto> productNotDeleted()
        {
            return _repository.productNotDeleted();
        }


        //createProducts
        public List<ProductDto> createProducts(List<CreateProductDto> p)
        {
            return _repository.createProducts(p);
        }

        //PaginationProducts
        public List<ProductDto> PaginationProducts(int page = 1, int size = 5)
        {
            return _repository.PaginationProducts(page, size);
        }

    }
}
