using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Assessment.Checks;
using Microsoft.SqlServer.Management.Smo;
using MyStudentMVC.Data;
using MyStudentMVC.Models;
using MyStudentMVC.Services;
using NuGet.Protocol.Plugins;

namespace MyStudentMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly StudentDbContext registrationDbContext;
        public RegistrationController(StudentDbContext registrationDbContext)
        {
            this.registrationDbContext = registrationDbContext;
        }
        [HttpGet]
        [Route("Registration/index")]
        [Authentication]
        public IActionResult Index()
        {
            return View(registrationDbContext.registrations.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddUser adduser)
        {
            if (ModelState.IsValid)
            {

                //check whether name is already exists in the database or not
                bool nameAlreadyExists = registrationDbContext.registrations.Any(s => s.userName == adduser.userName);


                if (nameAlreadyExists)
                {
                    ModelState.AddModelError(string.Empty, "user already exists.");

                    return View(adduser);
                }
            }

            var user = new Registration()
            {
                Id = adduser.Id,
                userName = adduser.userName,
                password = adduser.password,
                email = adduser.email,
            };

            await registrationDbContext.registrations.AddAsync(user);
            await registrationDbContext.SaveChangesAsync();
            //studentList.Add(student);
            return RedirectToAction("login", "Login");
        }
        [HttpGet]
        public ActionResult Details(Registration Rgs)
        {
            var user = registrationDbContext.registrations.Where(s => s.Id == Rgs.Id).First();
            return View(user);
        }

    }
}
