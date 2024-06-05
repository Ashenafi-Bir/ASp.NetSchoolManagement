using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
      
    }

    public class CourseAssignment
    {
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
