// Models/School/Student.cs
using System.Collections.Generic;
using EduFitMart.Models.Fitness;
using EduFitMart.Models.ECommerce;
using EduFitMart.Models.Integration;

namespace EduFitMart.Models.School
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // School Management (1:M with Enrollment)
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        // Fitness Tracker (M:M with Workout via StudentWorkout)
        public ICollection<StudentWorkout> StudentWorkouts { get; set; } = new List<StudentWorkout>();

        // E-Commerce (1:M with Order)
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}