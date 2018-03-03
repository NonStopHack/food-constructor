using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodConstructor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Use this application to get meal that you want";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Don't be shy to contact us!";

            return View();
        }
    }
}