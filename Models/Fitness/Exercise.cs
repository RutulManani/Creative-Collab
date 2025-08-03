// Models/Fitness/Exercise.cs
using System.Collections.Generic;

namespace EduFitMart.Models.Fitness
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public string Difficulty { get; set; }

        // M:M with Workout
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();

        // M:M with Equipment
        public ICollection<ExerciseEquipment> ExerciseEquipments { get; set; } = new List<ExerciseEquipment>();
    }
}