using ex01.Data;
using ex01.Dto;
using ex01.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ex01.Repositories
{
    public class ProductRepository
    {
        StoreDbContext context = StoreContextFactory.CreateContext();

        public List<ProductDto> GetProductByCategory(string ca="")
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
        public List<ProductDto> GetProductOrderByName(string ca = "")
        {
            return context.products.Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).OrderBy(x=>x.Name).ToList();
        }
        public List<ProductWithCategoriesDto> GetProductWithCategories(string ca = "")
        {
            return context.products.Include(x=>x.Categories).Select(a => new ProductWithCategoriesDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
                Categories = a.Categories   
            }).OrderBy(x => x.Name).ToList();
        }
        public ProductDto deleteProduct(string id)
        {
            var item= context.products.Where(y => y.Id==id).ToList();
            item[0].IsDeleted = true;
            context.SaveChanges();
            return new ProductDto()
            {
                Name = item[0].Name,
                Desc = item[0].Desc,
                ImageUrl = item[0].ImageUrl,
                Price = item[0].Price,
            };
        }
        public List<ProductDto> productNotDeleted()
        {
            return context.products.Where(x => !x.IsDeleted). Select(a => new ProductDto()
            {
                Name = a.Name,
                Desc = a.Desc,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
            }).ToList();    
        }
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
                    Categories= products[i].Categories
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
        public List<BagDto> bags()
        {
           return context.bags.Include(x => x.Product).Select(x => new BagDto() {Id=x.Id,Product=x.Product }).ToList();
           
        }
        //public int CreateCategoryWithProc(string name)
        //{
        //    var outputParam = new SqlParameter
        //    {
        //        ParameterName = "@NewId",
        //        SqlDbType = System.Data.SqlDbType.Int,
        //        Direction = System.Data.ParameterDirection.Output
        //    };

        //    var parameters = new[]
        //    {
        //        new SqlParameter("@Name", name),
        //        outputParam
        //     };


        //    context.Database.ExecuteSqlRaw(
        //    "EXEC spAddCategory @Name,@NewId OUTPUT",
        //    parameters);

        //    // Get the output value
        //    int newId = (int)outputParam.Value;


        //    return newId;
        //}

        //public void userWithBag()
        //{
        //    using var transaction = context.Database.BeginTransaction();
        //    try
        //    {
                
        //        transaction.Commit();
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}
    }
}
