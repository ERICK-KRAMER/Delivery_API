using Delivery.Models;
using Delivery.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrder();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByID(Guid id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            var newOrder = await _orderRepository.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderByID), new { id = newOrder.ID }, newOrder);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> RemoveOrder(Guid id)
        {
            var result = await _orderRepository.DeleteOrder(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Order>> GetOrderByUserId(Guid userId)
        {
            var order = await _orderRepository.GetOrderByUserId(userId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
