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