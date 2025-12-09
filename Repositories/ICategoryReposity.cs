
namespace ex01.Repositories
{
    public interface ICategoryReposity
    {
        bool CreateCategory(string name);
        List<string> GetCategories();
    }
}