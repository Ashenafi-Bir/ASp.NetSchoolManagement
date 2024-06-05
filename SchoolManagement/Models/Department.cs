using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; } = null;

        [Required]
        [StringLength(50)]
        public string? College { get; set; } = null;

        public ICollection<Course>? Courses { get; set; }
    }
}
