using Microsoft.EntityFrameworkCore;

namespace ex01.Data
{
    public class StoreContextFactory
    {
        private const string ConnectionString = "Server=Srv2\\pupils;DataBase=Store_216308940__1;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";
        public static StoreDbContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}
