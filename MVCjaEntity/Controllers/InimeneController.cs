using MVCjaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCjaEntity.Controllers
{
    public class InimeneController : Controller
    {
        static List<Inimene> inimesed = new List<Inimene>
            {
                new Inimene {Nr=1, Nimi = "Henn", Vanus= 68},
                new Inimene {Nr=2, Nimi = "Ants", Vanus= 40},

            };

        // GET: Inimene
        public ActionResult Index()
        {
            
                ;

            return View(inimesed);
        }

        // GET: Inimene/Details/5
        public ActionResult Details(int id)
        {
            var inimene = inimesed[id-1];

            return View(inimene);
        }

        // GET: Inimene/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inimene/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inimene/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inimene/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inimene/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inimene/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
