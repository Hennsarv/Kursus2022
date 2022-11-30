using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class InimeneController : Controller
    {
        // GET: Inimene
        public ActionResult Index()
        {
            var inimesed = Inimene
                .Inimesed
                .Values
                .ToList();
            return View("List",inimesed);
        }

        // GET: Inimene/Details/5
        public ActionResult Details(int id)
        {
            var inimene = Inimene.Inimesed[id];
            return View(inimene);
        }

        // GET: Inimene/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inimene/Create
        [HttpPost]
        public ActionResult Create(string Nimi, int Vanus)
        {
            try
            {
                int id = Inimene.Inimesed.Keys.Max() + 1;

                Inimene.Inimesed.Add(
                    id, new Inimene
                    {
                        Id = id,
                        Nimi = Nimi,
                        Vanus = Vanus
                    }
                    );

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
            var inimene = Inimene.Inimesed[id];
            return View(inimene);
        }

        // POST: Inimene/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string Nimi, int Vanus)
        {
            try
            {
                var inimene = Inimene.Inimesed[id];
                inimene.Nimi = Nimi;
                inimene.Vanus = Vanus;

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
            var inimene = Inimene.Inimesed[id];
            return View(inimene);
        }

        // POST: Inimene/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Inimene.Inimesed.Remove(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
