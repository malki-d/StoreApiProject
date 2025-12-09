
namespace ex01.Services
{
    public interface ICategoryService
    {
        bool CreateCategory(string name);
        List<string> GetCategories();
    }
}