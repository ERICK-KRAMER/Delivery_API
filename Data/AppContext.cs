using Delivery.Model.Order;
using Delivery.Model.Product;
using Delivery.Model.User;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data
{
    public class AppContext : DbContext
    {

        DbSet<User> User { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "");
            base.OnConfiguring(optionsBuilder);
        }
    }
}