using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWMM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }


        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
