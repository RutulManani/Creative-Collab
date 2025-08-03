// Models/Integration/StudentWorkout.cs (Junction Table)
using EduFitMart.Models.School;
using EduFitMart.Models.Fitness;

namespace EduFitMart.Models.Integration
{
    public class StudentWorkout
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}