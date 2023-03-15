using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MyStudentMVC.Services
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("userName") == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                        { "Controller", "Login" },
                            { "Action", "login" }
                });
            }
        }
    }
}