using ex01.Dto;

namespace ex01.Services
{
    public interface IBagService
    {
        bool CreateBag(CreateBagDto createBagDto);
        List<BagDto> GetBags();
    }
}