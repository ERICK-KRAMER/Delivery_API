using Delivery.Models;

namespace Delivery.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();
        Task<Order?> GetOrderById(Guid id);
        Task<Order> CreateOrder(Order order);
        Task<bool> DeleteOrder(Guid id);
        Task<Order?> GetOrderByUserId(Guid userId);
    }
}