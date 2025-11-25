using ex01.Models;
using Microsoft.EntityFrameworkCore;
namespace ex01.Data
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options) { }
        public DbSet<Product> products=>Set<Product>();
        public DbSet<Category> categories => Set<Category>();
        public DbSet<Bag> bags => Set<Bag>();
        public DbSet<User> users => Set<User>();

        public object Database { get; internal set; }
    }
}
