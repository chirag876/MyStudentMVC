using Microsoft.EntityFrameworkCore;
using MyStudentMVC.Models;
using System.Collections.Generic;

namespace MyStudentMVC.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {
        }

        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> StudentInformation { get; set; }

        public DbSet<Registration> registrations { get; set; }
        public DbSet<MyStudentMVC.Models.ContactQuery> ContactQuery { get; set; }

        public DbSet<MyStudentMVC.Models.UpdateStudent> UpdateStudent { get; set; }

        public DbSet<MyStudentMVC.Models.AddUser> AddUser { get; set; }

        public DbSet<MyStudentMVC.Models.Login> Login { get; set; }

        public DbSet<MyStudentMVC.Models.UpdatePassword> UpdatePassword { get; set; }

        
    }
}