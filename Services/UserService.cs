using ex01.Dto;
using ex01.Repositories;

namespace ex01.Services
{
    public class UserService
    {
        private readonly UserRepository _repository = new();

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
