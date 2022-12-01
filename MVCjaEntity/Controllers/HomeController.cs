using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCjaEntity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            ViewBag.Oluline = "Oluline info";
            ViewData["veelOlulisem"] = "veel olulisem info";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test(int a = 0, int b = 0, int c = 0) 
        { 
            ViewBag.a = a; 
            ViewBag.b = b;
            ViewBag.c = c;
            ViewBag.Teade = $"a={a} b={b} c={c} summa={a+b}";
            return View();
        }
    }
}