// Models/Fitness/Equipment.cs
using System.Collections.Generic;

namespace EduFitMart.Models.Fitness
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // M:M with Exercise
        public ICollection<ExerciseEquipment> ExerciseEquipments { get; set; } = new List<ExerciseEquipment>();
    }
}