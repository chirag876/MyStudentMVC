using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MyStudentMVC.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
     
        public string email { get; set; }
    }

   
}
