using ex01.Data;
using ex01.Dto;
using ex01.Models;

namespace ex01.Repositories
{
    public class UserRepository
    {
        StoreDbContext context = StoreContextFactory.CreateContext();


        //GetUsers
        public List<UserDto> GetUsers()
        {
            return context.users
            .Select(a => new UserDto()
            {
                Name = a.Name,
                Email = a.Email
            }).ToList();
        }


        //CreateUser
        public bool CreateUser(UserDto createBagDto)
        {
            try
            {
                context.users.Add(new User()
                {
                    Name = createBagDto.Name,
                    Email = createBagDto.Email
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
