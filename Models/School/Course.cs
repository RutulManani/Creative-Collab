using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduFitMart.Models.School
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100)]
        public string CourseName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}