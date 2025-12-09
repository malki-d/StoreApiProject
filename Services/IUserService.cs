using ex01.Dto;

namespace ex01.Services
{
    public interface IUserService
    {
        bool CreateUser(UserDto userDto);
        List<UserDto> GetUsers();
    }
}