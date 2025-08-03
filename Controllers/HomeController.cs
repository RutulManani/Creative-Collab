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
            var stats = new
            {
                TotalStudents = await _context.Students.CountAsync(),
                TotalCourses = await _context.Courses.CountAsync(),
                TotalWorkouts = await _context.Workouts.CountAsync(),
                TotalOrders = await _context.Orders.CountAsync(),
                RecentStudents = await _context.Students
                    .OrderByDescending(s => s.StudentId)
                    .Take(5)
                    .ToListAsync(),
                RecentOrders = await _context.Orders
                    .Include(o => o.Student)
                    .OrderByDescending(o => o.OrderDate)
                    .Take(5)
                    .ToListAsync()
            };

            return View(stats);
        }
    }
}