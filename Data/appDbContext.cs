using Delivery.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Delivery.AppDbContext
{
    public class AppDbContext : DbContext
    {
        //Search in browser Conection Strings;
        //https://www.connectionstrings.com/sql-server/

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "Host=ep-yellow-star-a5ntju2r.us-east-2.aws.neon.tech;Username=suplement-store_owner;Password=1BW8YClMQAJw;Database=Delivery;SslMode=Require");
            base.OnConfiguring(optionsBuilder);
        }
    }
}