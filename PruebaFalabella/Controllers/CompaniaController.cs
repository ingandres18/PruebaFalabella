using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaFalabella.Models;

namespace PruebaFalabella.Controllers
{
    [Authorize]
    public class CompaniaController : BaseController
    {
        private FalabellaContext db = new FalabellaContext();

        // GET: Compania
        public ActionResult Index()
        {
            return View(db.Compania.ToList());
        }

        // GET: Compania/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compania compania = db.Compania.Find(id);
            if (compania == null)
            {
                return HttpNotFound();
            }
            return View(compania);
        }

        // GET: Compania/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compania/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Ciudad")] Compania compania)
        {
            if (ModelState.IsValid)
            {
                db.Compania.Add(compania);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compania);
        }

        // GET: Compania/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compania compania = db.Compania.Find(id);
            if (compania == null)
            {
                return HttpNotFound();
            }
            return View(compania);
        }

        // POST: Compania/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Ciudad")] Compania compania)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compania).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compania);
        }

        // GET: Compania/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compania compania = db.Compania.Find(id);
            if (compania == null)
            {
                return HttpNotFound();
            }
            return View(compania);
        }

        // POST: Compania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compania compania = db.Compania.Find(id);
            db.Compania.Remove(compania);
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
