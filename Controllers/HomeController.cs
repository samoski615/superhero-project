using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "If you wanna know about me just ask.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Hello There!";

            return View();
        }
    }
}