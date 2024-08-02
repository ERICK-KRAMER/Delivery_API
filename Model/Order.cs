namespace Delivery.Models
{
    public class Order
    {
        public Guid ID { get; init; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
    }
}