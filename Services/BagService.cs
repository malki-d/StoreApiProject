using ex01.Dto;
using ex01.Repositories;

namespace ex01.Services
{
    public class BagService : IBagService
    {
        private readonly IBagRepository _repository ;
        public BagService(IBagRepository repository)
        {
             _repository=repository;
        }

        //GetBags
        public List<BagDto> GetBags()
        {
            return _repository.GetBags();
        }

        //CreateBag
        public bool CreateBag(CreateBagDto createBagDto)
        {
            return _repository.CreateBag(createBagDto);

        }
    }
}
