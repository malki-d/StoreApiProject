using ex01.Data;
using ex01.Dto;
using ex01.Models;

namespace ex01.Repositories
{
    public class CategoryReposity : ICategoryReposity
    {
        private readonly StoreDbContext context;
        public CategoryReposity(StoreDbContext context1)
        {
            context = context1;
        }

        //GetCategories
        public List<string> GetCategories()
        {
            return context.categories
            .Select(a => a.Name)
            .ToList();
        }


        //CreateCategory
        public bool CreateCategory(string name)
        {
            try
            {
                context.categories.Add(new Category()
                {
                    Name = name
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
