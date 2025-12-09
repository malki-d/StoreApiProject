using ex01.Dto;
using ex01.Repositories;

namespace ex01.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReposity _repository ;
        public CategoryService(ICategoryReposity repository)
        {
            _repository = repository;
        }

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
