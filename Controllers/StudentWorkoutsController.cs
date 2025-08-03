using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduFitMart.Data;
using EduFitMart.Models.Integration;
using EduFitMart.Models.School;
using EduFitMart.Models.Fitness;

namespace EduFitMart.Controllers
{
    public class StudentWorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentWorkouts/Create?studentId=5
        public IActionResult Create(int studentId)
        {
            var availableWorkouts = _context.Workouts
                .Where(w => !_context.StudentWorkouts.Any(sw => sw.StudentId == studentId && sw.WorkoutId == w.WorkoutId))
                .ToList();

            ViewBag.StudentId = studentId;
            ViewBag.StudentName = _context.Students.Find(studentId)?.Name;
            return View(availableWorkouts);
        }

        // POST: StudentWorkouts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int studentId, int workoutId)
        {
            _context.StudentWorkouts.Add(new StudentWorkout
            {
                StudentId = studentId,
                WorkoutId = workoutId
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Students", new { id = studentId });
        }

        // POST: StudentWorkouts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int studentId, int workoutId)
        {
            var studentWorkout = await _context.StudentWorkouts
                .FirstOrDefaultAsync(sw => sw.StudentId == studentId && sw.WorkoutId == workoutId);

            if (studentWorkout != null)
            {
                _context.StudentWorkouts.Remove(studentWorkout);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Students", new { id = studentId });
        }
    }
}