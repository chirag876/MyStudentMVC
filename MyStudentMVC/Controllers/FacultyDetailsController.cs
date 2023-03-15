using Microsoft.AspNetCore.Mvc;

using MyStudentMVC.Models;

namespace MyStudentMVC.Controllers
{
    public class FacultyDetailsController : Controller
    {
        static IList<FacultyForm> FacultyList = new List<FacultyForm>
        {
                new FacultyForm() { Id = 1, FacultyName = "Chirag",PhoneNumber= 67785537318 , Designation="" , Email = "", Gender = "", Grade= "", Password="" },
                new FacultyForm() { Id = 2, FacultyName = "Chavvi",PhoneNumber= 7838327321 ,  Designation="" , Email = "", Gender = "", Grade= "", Password="" },
                new FacultyForm() { Id = 3, FacultyName = "Shubhi", PhoneNumber =  753627225  , Designation="" , Email = "", Gender = "",Grade = "", Password="" },
                new FacultyForm() { Id = 4, FacultyName = "Aman" , PhoneNumber= 77898928220  ,Designation="" , Email = "", Gender = "", Grade= "", Password="" },
                new FacultyForm() { Id = 5, FacultyName = "Aditya", PhoneNumber = 73732727831,Designation="" , Email = "", Gender = "", Grade= "", Password="" },
                new FacultyForm() { Id = 6, FacultyName = "Vinay" ,PhoneNumber= 723788717    ,Designation="" , Email = "", Gender = "", Grade= "", Password="" },
                new FacultyForm() { Id = 7, FacultyName = "Sejal" ,PhoneNumber= 9823823919   ,Designation="" , Email = "", Gender = "", Grade= "", Password="" },
            };

        static IList<ContactQuery> Contactlist = new List<ContactQuery>
        {
            new ContactQuery()
            {
                FullName="Chirag", Country="India", Message="Welcome"
            }
        };
        public FacultyDetailsController()
        {
        }

        public IActionResult Index()
        {
            return View(FacultyList.OrderBy(s => s.Id).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddFaculty addFaculty)
        {
            if (ModelState.IsValid)
            {
                var facultyregistration = new FacultyForm()
                {
                    Id = addFaculty.Id,
                    Gender = addFaculty.Gender,
                    Password = addFaculty.Password,
                    PhoneNumber = addFaculty.PhoneNumber,
                    Designation = addFaculty.Designation,
                    Email = addFaculty.Email,
                    FacultyName = addFaculty.FacultyName,
                    Grade = addFaculty.grade

                };
                FacultyList.Add(facultyregistration);


            }
            //await studentDbContext.StudentDetails.AddAsync(student);
            //await studentDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Display()
        {
            return View();
        }

        public IActionResult ContactIndex()
        {

            return View(Contactlist.ToList());
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactQuery contact)
        {
            var contactquery = new ContactQuery()
            {
                FullName = contact.FullName,
                Country = contact.Country,
                Message = contact.Message,
            };

            Contactlist.Add(contactquery);
            return RedirectToAction("ContactIndex");

        }


    }
}
