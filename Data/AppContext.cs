using Delivery.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
               .HasOne<User>()
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserID);

            modelBuilder.Entity<Order>()
                .HasOne<Product>()
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ep-yellow-star-a5ntju2r.us-east-2.aws.neon.tech;Database=Delivery_C#;Username=suplement-store_owner;Password=1BW8YClMQAJw;sslmode=require");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
