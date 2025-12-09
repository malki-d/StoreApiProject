using ex01.Dto;

namespace ex01.Repositories
{
    public interface IUserRepository
    {
        bool CreateUser(UserDto createBagDto);
        List<UserDto> GetUsers();
    }
}