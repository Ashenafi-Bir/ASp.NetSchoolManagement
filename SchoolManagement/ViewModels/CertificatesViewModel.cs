using SchoolManagement.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.ViewModels
{
    public class CertificatesViewModel
    {
        [Required]
        public int SearchId { get; set; }

        public Student? Student { get; set; }

        public List<Enrollment>? Enrollments { get; set; }
    }
}
