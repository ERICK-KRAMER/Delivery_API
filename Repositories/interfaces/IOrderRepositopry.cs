using Delivery.Models;

namespace Delivery.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();
        Task<Order?> GetOrderById(Guid id);
        Task<Order> CreateOrder(Order order);
        Task DeleteOrder(Guid id);
    }
}