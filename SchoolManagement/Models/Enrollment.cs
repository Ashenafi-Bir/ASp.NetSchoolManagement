using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Course? Course { get; set; }
        public Student? Student { get; set; }

        [Range(0, 100)]
        public int Grade { get; set; }
    }
}
