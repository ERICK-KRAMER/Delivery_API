using Delivery.Data;
using Delivery.Model.Order;
using Delivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _dbContext;
        public OrderRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrder(Guid id)
        {
            var findOrder = await GetOrderById(id);
            if (findOrder != null)
            {
                _dbContext.Orders.Remove(findOrder);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderById(Guid id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order => order.ID == id);
        }

    }
}
