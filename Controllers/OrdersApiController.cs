using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMSbackend.Data;
using GiftelleCMSbackend.Models;
using GiftelleCMSbackend.DTOs;

namespace GiftelleCMSbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await _context.Orders
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName
                }).ToListAsync();

            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            var dto = new OrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                CustomerName = order.CustomerName
            };

            return Ok(dto);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDto)
        {
            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                CustomerName = orderDto.CustomerName
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            orderDto.OrderId = order.OrderId;

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, orderDto);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDto)
        {
            if (id != orderDto.OrderId)
                return BadRequest();

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            order.OrderDate = orderDto.OrderDate;
            order.CustomerName = orderDto.CustomerName;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
