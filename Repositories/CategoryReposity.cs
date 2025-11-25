using ex01.Data;
using ex01.Dto;
using ex01.Models;

namespace ex01.Repositories
{
    public class CategoryReposity
    {
        StoreDbContext context = StoreContextFactory.CreateContext();


        //GetCategories
        public List<string> GetCategories()
        {
            return context.categories
            .Select(a =>a.Name )
            .ToList();
        }


        //CreateCategory
        public bool CreateCategory(string name)
        {
            try
            {
                context.categories.Add(new Category()
                {
                   Name=name
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
