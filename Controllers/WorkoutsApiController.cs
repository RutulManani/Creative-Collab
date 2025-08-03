using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduFitMart.Data;
using EduFitMart.Models.Fitness;

namespace EduFitMart.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/WorkoutsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // PUT: api/WorkoutsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.WorkoutId)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkoutsApi
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout", new { id = workout.WorkoutId }, workout);
        }

        // DELETE: api/WorkoutsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/WorkoutsApi/5/exercises
        [HttpGet("{id}/exercises")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetWorkoutExercises(int id)
        {
            var workout = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout.WorkoutExercises.Select(we => we.Exercise));
        }

        // POST: api/WorkoutsApi/5/exercises/3
        [HttpPost("{workoutId}/exercises/{exerciseId}")]
        public async Task<IActionResult> AddExerciseToWorkout(int workoutId, int exerciseId)
        {
            var workout = await _context.Workouts.FindAsync(workoutId);
            var exercise = await _context.Exercises.FindAsync(exerciseId);

            if (workout == null || exercise == null)
            {
                return NotFound();
            }

            if (!_context.WorkoutExercises.Any(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId))
            {
                _context.WorkoutExercises.Add(new WorkoutExercise
                {
                    WorkoutId = workoutId,
                    ExerciseId = exerciseId
                });
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: api/WorkoutsApi/5/exercises/3
        [HttpDelete("{workoutId}/exercises/{exerciseId}")]
        public async Task<IActionResult> RemoveExerciseFromWorkout(int workoutId, int exerciseId)
        {
            var workoutExercise = await _context.WorkoutExercises
                .FirstOrDefaultAsync(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId);

            if (workoutExercise == null)
            {
                return NotFound();
            }

            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.WorkoutId == id);
        }
    }
}