using ex01.Dto;
using ex01.Repositories;

namespace ex01.Services
{
    public class CategoryService
    {
        private readonly CategoryReposity _repository = new();

        //GetCategories
        public List<string> GetCategories()
        {
            return _repository.GetCategories();
        }

        //CreateCategory
        public bool CreateCategory(string name)
        {
            return _repository.CreateCategory(name);

        }
    }
}
