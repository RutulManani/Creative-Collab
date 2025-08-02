using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMSbackend.Data;
using GiftelleCMSbackend.Models;

namespace GiftelleCMSbackend.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();

            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create() => View();

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
