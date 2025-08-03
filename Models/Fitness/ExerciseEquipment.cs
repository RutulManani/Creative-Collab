// Models/Fitness/ExerciseEquipment.cs (Junction Table)
namespace EduFitMart.Models.Fitness
{
    public class ExerciseEquipment
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}