using Delivery.Data;
using Delivery.Models;
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
            var order = await GetOrderById(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
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

        public async Task<Order?> GetOrderByUserId(Guid userId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order => order.UserID == userId);
        }
    }
}
