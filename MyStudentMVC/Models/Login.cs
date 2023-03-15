using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace MyStudentMVC.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
