
using Microsoft.EntityFrameworkCore;

namespace Mobiliva.Mulakat.DataAccess.Concrete.EntityFramework
{
    public class MulakatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string mySqlConnectionStr = "Server=localhost;Port=3306;Database=Mobiliva.Mulakat;Uid=root;Pwd=12345;";
            optionsBuilder.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
        }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}