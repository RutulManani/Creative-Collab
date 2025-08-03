// Models/Fitness/Workout.cs
using System.Collections.Generic;
using EduFitMart.Models.Integration;

namespace EduFitMart.Models.Fitness
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int? CaloriesEstimated { get; set; }

        // M:M with Exercise
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();

        // M:M with Student (via StudentWorkout)
        public ICollection<StudentWorkout> StudentWorkouts { get; set; } = new List<StudentWorkout>();
    }
}