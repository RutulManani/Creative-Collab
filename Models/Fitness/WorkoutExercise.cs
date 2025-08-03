// Models/Fitness/WorkoutExercise.cs (Junction Table)
namespace EduFitMart.Models.Fitness
{
    public class WorkoutExercise
    {
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}