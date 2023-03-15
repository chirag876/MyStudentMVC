using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStudentMVC.Data;
using MyStudentMVC.Models;

namespace MyStudentMVC.Controllers
{
    public class StudentController : Controller
    {
        //static IList<Student> studentList = new List<Student>{
        //        new Student() { Id = 1, Namodel e = "Chirag", Age = 18 } ,
        //        new Student() { Id = 2, Namodel e = "Chavvi",  Age = 21 } ,
        //        new Student() { Id = 3, Namodel e = "Shubhi",  Age = 25 } ,
        //        new Student() { Id = 4, Namodel e = "Amodel an" , Age = 20 } ,
        //        new Student() { Id = 5, Namodel e = "Aditya" , Age = 31 } ,
        //        new Student() { Id = 6, Namodel e = "Vinay" , Age = 17 } ,
        //        new Student() { Id = 7, Namodel e = "Sejal" , Age = 19 }
        //    };

        private readonly StudentDbContext studentDbContext;
        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        [Route("Student/index")]
        //GET: Student
        public IActionResult Index()
        {
            //List<Student> list = new List<Student>();
            //Student student = new Student();
            //student.Namodel e = "Chirag";
            //student.Age = 21;
            //student.Id = 1;
            //list.Add(student);


            //ViewBag.TotalStudents = studentList.Count();
            //ViewData["students"] = studentList;

            //return View();

            return View(studentDbContext.StudentInformation.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStudent addStudent)
        {
            var student = new Student()
            {
                Id = addStudent.Id,
                Name = addStudent.Name,
                Age = addStudent.Age
            };
            await studentDbContext.StudentInformation.AddAsync(student);
            await studentDbContext.SaveChangesAsync();
            //studentList.Add(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Student/Edit")]
        public ActionResult Edit(int Id)
        {

            var student = studentDbContext.StudentInformation.Where(s => s.Id == Id).FirstOrDefault();

            // update student to the database

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateStudent update)
        {
            //update student in DB using EntityFramodel ework in real-life application

            //update list by remodel oving old student and adding updated student for demodel o purpose
            var student = await studentDbContext.StudentInformation.FindAsync(update.Id);
            if (student != null)
            {
                student.Age = update.Age;
                student.Name = update.Name;
                await studentDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
            // var student = studentDbContext.StudentInformation.Where(s => s.Id == update.Id).FirstOrDefault();
            //studentDbContext.StudentInformation.Remove(student);
            //studentDbContext.StudentInformation.Add(update);


        }

        [HttpGet]
        public ActionResult Details(Student std)
        {
            var student = studentDbContext.StudentInformation.Where(s => s.Id == std.Id).First();
            return View(student);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var student = await studentDbContext.StudentInformation.FirstAsync(s => s.Id == Id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var student = await studentDbContext.StudentInformation.FindAsync(Id);
            {
        
                studentDbContext.StudentInformation.Remove(student);
                await studentDbContext.SaveChangesAsync();
                
            }
            return RedirectToAction("Index");
            //var student = studentDbContext.StudentInformation.Where(s => s.Id == Id).First();
            //studentDbContext.StudentInformation.Remove(student);
            //return RedirectToAction("Index");
        }

        public ActionResult About()
        {

            return View();
        }



        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    // delete student fromodel  DB using EntityFramodel ework in real-life application

        //    // delete student fromodel  list for demodel o purpose
        //    var student = studentList.Where(s => s.Id == std.Id).FirstOrDefault();
        //    if (student!= null)
        //    {
        //        studentList.Remodel ove(student);
        //    }

        //    return RedirectToAction("Index");
        //}

    }
}