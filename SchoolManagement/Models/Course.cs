using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Range(1, 5)]
        public int Credits { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
    }
}
