using SchoolManagement.Models;
using System.ComponentModel.DataAnnotations;
namespace SchoolManagement.ViewModels
{
    public class GenerateCoursesViewModel
    {
        [Required]
        public int SearchId { get; set; }
        public Instructor? Instructor { get; set; } = null!;
        public List<Course>? Courses { get; set; } = new List<Course>();
    }
}
