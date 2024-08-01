using Delivery.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "Host=ep-yellow-star-a5ntju2r.us-east-2.aws.neon.tech;Username=suplement-store_owner;Password=1BW8YClMQAJw;Database=Delivery;SslMode=Require");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
