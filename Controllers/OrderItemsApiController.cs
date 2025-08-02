using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMSbackend.Data;
using GiftelleCMSbackend.Models;
using GiftelleCMSbackend.DTOs;

namespace GiftelleCMSbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDTO>>> GetOrderItems()
        {
            var items = await _context.OrderItems
                .Select(o => new OrderItemDTO
                {
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity
                })
                .ToListAsync();

            return Ok(items);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItem(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null)
                return NotFound();

            var dto = new OrderItemDTO
            {
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };

            return Ok(dto);
        }

        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderItemDTO>> CreateOrderItem(OrderItemDTO dto)
        {
            var orderItem = new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.OrderItemId }, dto);
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItemDTO dto)
        {
            var existingItem = await _context.OrderItems.FindAsync(id);
            if (existingItem == null)
                return NotFound();

            existingItem.OrderId = dto.OrderId;
            existingItem.ProductId = dto.ProductId;
            existingItem.Quantity = dto.Quantity;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderItemId == id);
        }
    }
}
