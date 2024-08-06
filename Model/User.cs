namespace Delivery.Models
{
    public class User
    {
        public Guid ID { get; init; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // Aqui é onde o hash da senha será armazenado
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
