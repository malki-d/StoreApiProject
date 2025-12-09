using ex01.Dto;

namespace ex01.Repositories
{
    public interface IBagRepository
    {
        bool CreateBag(CreateBagDto createBagDto);
        List<BagDto> GetBags();
    }
}