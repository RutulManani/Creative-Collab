using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduFitMart.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EduFitMart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalStudents = await _context.Students.CountAsync();
            ViewBag.TotalWorkouts = await _context.Workouts.CountAsync();
            ViewBag.TotalOrders = await _context.Orders.CountAsync();

            ViewBag.RecentStudents = await _context.Students
                .OrderByDescending(s => s.StudentId)
                .Take(5)
                .ToListAsync();

            ViewBag.RecentOrders = await _context.Orders
                .Include(o => o.Student)
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToListAsync();

            return View();
        }
    }
}