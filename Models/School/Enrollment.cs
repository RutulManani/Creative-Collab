// Models/School/Enrollment.cs
namespace EduFitMart.Models.School
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        // Foreign Keys
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}