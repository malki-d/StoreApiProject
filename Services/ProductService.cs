using ex01.Dto;
using ex01.Models;
using ex01.Repositories;

namespace ex01.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository = new();


        public List<ProductDto> GetProductByCategory(string c)
        {
            return _repository.GetProductByCategory(c);
        }
        public List<ProductDto> GetProductOrderByName()
        {
            return _repository.GetProductOrderByName();
        }
        public List<ProductWithCategoriesDto> GetProductWithCategories()
        {
            return _repository.GetProductWithCategories();
        }
        public ProductDto deleteProduct(string id)
        {
            return _repository.deleteProduct(id);
        }
        public List<ProductDto> productNotDeleted()
        {
            return _repository.productNotDeleted();
        }
        public List<ProductDto> createProducts(List<CreateProductDto> p)
        {
            return _repository.createProducts(p);
        }
        public List<BagDto> bags()
        {
            return _repository.bags();
        }
        //public int CreateCategoryWithProc(string name)
        //{
        //    return _repository.CreateCategoryWithProc(name);
        //}
    }
}
