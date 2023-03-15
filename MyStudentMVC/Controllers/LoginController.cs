using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using MyStudentMVC.Data;
using MyStudentMVC.Models;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Login = MyStudentMVC.Models.Login;

namespace MyStudentMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly StudentDbContext loginDbContext;
        public LoginController(StudentDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult login()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult login()
        {
            if(HttpContext.Session.GetString("userName")==null)
            {
                return View();
            }

            return View();
        }


        [HttpPost]
        public ActionResult login(Login login)
        {

            //StudentDbContext loginDbContext = new StudentDbContext();
            //var check = loginDbContext.registrations.Any(m => m.userName == login.userName && m.password == login.Password);
            //if (check == true)
            //{}
            var check = loginDbContext.registrations.Where(a => a.userName.Equals(login.userName) && a.password.Equals(login.Password)).FirstOrDefault();
            if (check != null)
            {
                HttpContext.Session.SetString("userName", check.userName.ToString());
             
                TempData["Alert"] = "Login Succefully";
                string userName = " " + login.userName;
                TempData["User"] = "Welcome" + userName;
                return RedirectToAction("Index", "Home");//this was blocked and then was not redirecting
            }
            TempData["Alert1"] = "User Not Found";
            //return RedirectToAction("Create", "Registration");

            return View();
        }

        public ActionResult password(UpdatePassword updatePassword)
        {
            return View(updatePassword);
        }

        [HttpGet]

        public IActionResult password()
        {
            return View();
        }
        [HttpPost]
        [ActionName("password")]
        public IActionResult Password(UpdatePassword updatepassword)
        {
            var status = loginDbContext.registrations.FirstOrDefault(m => m.userName == updatepassword.userName);
            if (status != null)
            {
                status.password = updatepassword.Password;
                //userName = updatepassword.userName;
                //password = updatepassword.Password;
                loginDbContext.SaveChanges();
            }
            //await loginDbContext.registrations.AddAsync(status);
            //studentList.Add(student);
            return RedirectToAction("login", "Login");
        }

        //[Authorize]
        //public ActionResult Profile()//Login login)//Created a details view
        //{
        //    //var user = loginDbContext.registrations.FirstOrDefault(m => m.userName == login.userName); ;
        //    //return View(user);
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult GetDetails()
        //{
        //    var umodel = new Registration();
        //    umodel.userName = HttpContext.Request.Form["txtName"].ToString();
        //    umodel.email = HttpContext.Request.Form["txtemail"].ToString();//Convert.ToInt32(HttpContext.Request.Form["txtAge"]);
        //    umodel.password = HttpContext.Request.Form["txtpassword"].ToString();
        //    int result = umodel.SaveDetails();
        //    if (result > 0)
        //    {
        //        ViewBag.Result = "Data Saved Successfully";
        //    }
        //    else
        //    {
        //        ViewBag.Result = "Something Went Wrong";
        //    }
        //    return View("Profile");
        //}

        //[Authorize]
        //public IActionResult Profile()
        //{
        //    return View(new Registration()
        //    {
        //        userName = User.Identity.userName,
        //        email = User.FindFirst(c => c.Type == ClaimTypes.email)?.Value,
        //        password = User.FindFirst(c => c.Type == ClaimTypes.password)?.Value
        //    });
        //}

        //[HttpGet]
        //public ActionResult Profile(Login login)
        //{

        //    var user = loginDbContext.registrations.FirstOrDefault(m => m.userName == login.userName);
        //    //if (user == null)
        //    //{
        //    //    return View(user);
        //    //}
        //    return View(user);
        //}



        //[HttpGet]
        //public ActionResult Details(Student std)
        //{
        //    var student = studentDbContext.StudentInformation.Where(s => s.Id == std.Id).First();
        //    return View(student);
        //}
        //public ActionResult Profile(Login u)
        //{
        //    // this action is for handle post (login)
        //    if (ModelState.IsValid) // this is check validity
        //    {

        //        //var v = dc.service_provider.Where(a => a.Sp_email.Equals(u.Email) && a.Sp_password.Equals(u.Password)).FirstOrDefault();
        //        var check = loginDbContext.registrations.Where(a => a.userName.Equals(u.userName) && a.password.Equals(u.Password)).FirstOrDefault();
        //        if (check != null)
        //            {
        //                //return RedirectToAction("AfterLogin");

        //                string userName = u.userName; // assign your valid user's id and pass it to AfterLogin Action
        //                return RedirectToAction("AfterLogin", new { @userName = userName });
        //            }
                
        //    }
        //    return View(u);
        //}


        //public ActionResult AfterLogin(string userName)
        //{
        //    Login u = loginDbContext.registrations.FirstOrDefault(m=>m.userName==userName);// select your user's data using id and assign to a user object 
        //return View(u); // and pass the user object to view
        //}
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("userName");
            return RedirectToAction("login", "Login");
        }
    }


    }
