using Microsoft.AspNetCore.Mvc;
using MyStudentMVC.Models;

namespace MyStudentMVC.Controllers
{
    public class ContactQueryController : Controller
    {
        

        public ContactQueryController()
        {
            
        }
        

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(ContactQuery contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var contactquery = new ContactQuery()
        //        {
        //            FullName = contact.FullName,
        //            Country = contact.Country,
        //            Message = contact.Message,
        //        };

        //        Contactlist.Add(contactquery);
        //        return RedirectToAction("Index");

        //    }
        //    return View();
        //}
    }
}
