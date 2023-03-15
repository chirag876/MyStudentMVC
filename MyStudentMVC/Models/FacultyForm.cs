
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStudentMVC.Models
{
    public class FacultyForm
    {
        public int Id { get; set; }
        [Display(Name = "FacultyName")]
        [Required]
        public string FacultyName { get; set; }
        public long PhoneNumber { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Designation { get; set; }

        public string Gender { get; set; }

        public string Grade { get; set; }






    }


}
