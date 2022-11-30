using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Tere(string id, int? a, int? b)
        {
            ViewBag.Id = id;
            ViewBag.a = a; ViewBag.b = b;
            ViewBag.s = (a ?? 0) + (b ?? 0);
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Niisama()
        {
            return View();
        }

        public ActionResult About(int? id)
        {
            ViewBag.Message = $"Keegi ütles {id} {Request.QueryString}";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}