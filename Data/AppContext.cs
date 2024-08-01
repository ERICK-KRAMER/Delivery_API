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

namespace Delivery.Model.User
{
    public class User
    {
        public Guid ID { get; init; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}

namespace Delivery.Model.Product
{
    public class Product
    {
        public Guid ID { get; init; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string? Description { get; set; }
    }
}

namespace Delivery.Model.Order
{
    public class Order
    {
        public Guid ID { get; init; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
    }
}