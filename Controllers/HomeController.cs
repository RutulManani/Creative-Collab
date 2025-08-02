using Microsoft.AspNetCore.Mvc;
using GiftelleCMSbackend.Data;
using GiftelleCMSbackend.Models;
using System.Linq;

namespace GiftelleCMSbackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalVendors = _context.Vendor.Count(),
                TotalProducts = _context.Products.Count(),
                TotalOrders = _context.Orders.Count(),
                TotalOrderItems = _context.OrderItems.Count()
            };

            return View(model);
        }
    }
}
