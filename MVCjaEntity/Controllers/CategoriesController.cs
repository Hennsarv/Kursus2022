using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCjaEntity.Models;

namespace MVCjaEntity.Controllers
{
    public class CategoriesController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Categories
        public ActionResult Index(int id = 0, string nimi = "")
        {
            return View(db.Categories
                .Where(x => (id == 0) || (x.CategoryID == id))
                // .ToList() // seda on vaja, kui keerukat Where'i ei saa SQL keeles kirjutada
                // seda .tolisti siia vahele pole vaja
                // kuna tark SQLi mees oskab ka selle alumise asja
                // teha SQL lauseks
                .Where(x => (nimi == "") || (x.CategoryName.Substring(0,nimi.Length) == nimi))
                .ToList());
        }

        public ActionResult Picture(int id = 0)
        {
            var cat = db.Categories.Find(id);
            if (cat == null) return HttpNotFound();
            if(cat.Picture == null || cat.Picture.Length == 0) 
                return new HttpNotFoundResult { };   
            byte[] pilt = cat.Picture;
            
            // järgmine rida on seotud NW andmebaasi ajalooga
            // need pildid mis seal ON on vähe vigased
            if (pilt[0] == 21) pilt = pilt.Skip(78).ToArray();
            
            return File(pilt, "image/jpg");
        }

        public ActionResult Tooted(int id = 0, string nimi = "")
        {
            var products = db.Products.Include(p => p.Category)
                .Where(x => (nimi == "") || (x.ProductName.Substring(0, nimi.Length) == nimi))
                .Where(x => (id) == 0 || x.CategoryID == id)
                ;

            // Näide, kuidas viidata hoopis teises sahtlis olevale Viewle
            return View("../Products/Index",products.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)    
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CategoryID,CategoryName,Description")] Category category, 
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // kui ma mõne elemendi eemaldan Edit vormilt
                // siis on oluline et vastav property muudatus ette
                // tühistada - et ei juhtuks jama
                var cat = db.Entry(category);
                cat.State = EntityState.Modified;
                cat.Property(x => x.Picture).IsModified = false;
                
                //db.SaveChanges();
                if((file?.ContentLength??0) > 0)
                {
                    using(System.IO.BinaryReader br = 
                        new System.IO.BinaryReader(file.InputStream))
                    {
                        byte[] buff = br.ReadBytes(file.ContentLength);
                        category.Picture = buff;
                        
                    }
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
