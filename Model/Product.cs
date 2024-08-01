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