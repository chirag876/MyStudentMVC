using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MyStudentMVC.Models
{
    public class AddFaculty
    {
        public int Id { get; set; }

        [Required]
        public string FacultyName { get; set; }

        public long PhoneNumber { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Designation { get; set; }

        public string Gender { get; set; }

        public string grade { get; set; }
    }
}
