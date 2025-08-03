// Models/School/Course.cs
using System.Collections.Generic;

namespace EduFitMart.Models.School
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // 1:M with Enrollment
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}