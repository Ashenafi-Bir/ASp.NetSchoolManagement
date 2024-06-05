using SchoolManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.ViewModels
{
    public class CoursesInstructorsViewModel
    {
        public int SearchId { get; set; }
        public Department? Department { get; set; } = null!;
        public List<Course>? Courses { get; set; } = new List<Course>();
    }
}
