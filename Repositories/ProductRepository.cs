using ex01.Data;
using ex01.Dto;
using ex01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ex01.Repositories
{
    public class ProductRepository
    {
        StoreDbContext context = StoreContextFactory.CreateContext();


        //GetProducts
        public List<ProductDto> GetProducts()
        {
            return context.products
            .Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).ToList();
        }

        //GetProductById
        public ProductDto GetProductById(int id)
        {
            var items = context.products.Where(y => y.Id == id).ToList();
            return new ProductDto()
            {
                Name = items[0].Name,
                Desc = items[0].Desc,
                ImageUrl = items[0].ImageUrl,
                Price = items[0].Price,
            };
        }

        //UpdateProduct
        public ProductDto UpdateProduct(int id, Product p)
        {
            var items = context.products.Where(y => y.Id == id).ToList();
            var item = items[0];
            item.Name = p.Name;
            item.ImageUrl = p.ImageUrl;
            item.Price = p.Price;
            item.Desc = p.Desc;
            item.Sale= p.Sale;
            item.Colors = p.Colors;
            context.SaveChanges();
            return GetProductById(id);
        }

        //GetProductByCategory
        public List<ProductDto> GetProductByCategory(string ca = "")
        {
            return context.products
            .Include(c => c.Categories)
            .Where(c => c.Categories.Where(c => c.Name == ca).Count() != 0)
            .Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).ToList();
        }


        //GetProductOrderByName
        public List<ProductDto> GetProductOrderByName()
        {
            return context.products.Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).OrderBy(x => x.Name).ToList();
        }


        //GetProductWithCategories
        public List<ProductWithCategoriesDto> GetProductWithCategories()
        {
            return context.products.Include(x => x.Categories).Select(a => new ProductWithCategoriesDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
                Categories = a.Categories
            }).OrderBy(x => x.Name).ToList();
        }


        //deleteProduct
        public ProductDto deleteProduct(int id)
        {
            var items = context.products.Where(y => y.Id == id).ToList();
            var item = items[0];
            item.IsDeleted = true;
            context.SaveChanges();
            return GetProductById(id);
        }


        //productNotDeleted
        public List<ProductDto> productNotDeleted()
        {
            return context.products.Where(x => !x.IsDeleted).Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).ToList();
        }



        //createProducts
        public List<ProductDto> createProducts(List<CreateProductDto> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                context.products.Add(new Product()
                {
                    Name = products[i].Name,
                    Desc = products[i].Desc,
                    ImageUrl = products[i].ImageUrl,
                    Price = products[i].Price,
                    Categories = products[i].Categories
                });
            }
            context.SaveChanges();
            return context.products.Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).ToList();
        }


        //PaginationProducts
        public List<ProductDto> PaginationProducts( int page = 1, int size = 5)
        {            
            return GetProducts()
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();
        }

    }
}
