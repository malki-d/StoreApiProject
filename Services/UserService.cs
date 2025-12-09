using ex01.Dto;
using ex01.Repositories;

namespace ex01.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository ;
        public UserService(IUserRepository repository)
        {
            _repository = repository ;
        }

        //GetUsers
        public List<UserDto> GetUsers()
        {
            return _repository.GetUsers();
        }

        //CreateUser
        public bool CreateUser(UserDto userDto)
        {
            return _repository.CreateUser(userDto);

        }
    }
}
