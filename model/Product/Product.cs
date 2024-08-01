namespace Delivery.Models.Product
{
    public class Product
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public Product(string name, string description, decimal price, decimal discountPercent)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            DiscountPercent = discountPercent;
        }
    }
}