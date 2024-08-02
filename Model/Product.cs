namespace Delivery.Models
{
    public class Product
    {
        public Guid ID { get; init; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
