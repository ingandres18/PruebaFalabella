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
    public class AsesorController : BaseController
    {
        private FalabellaContext db = new FalabellaContext();

        // GET: Asesor
        public ActionResult Index()
        {
            return View(db.Asesor.ToList());
        }

        // GET: Asesor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesor.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // GET: Asesor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asesor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrimerNombre,SegundoNombre,PrimerApelldo,SegundoApellido,Correo,Clave")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                db.Asesor.Add(asesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesor);
        }

        // GET: Asesor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesor.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // POST: Asesor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrimerNombre,SegundoNombre,PrimerApelldo,SegundoApellido,Correo,Clave")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asesor);
        }

        // GET: Asesor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesor.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // POST: Asesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asesor asesor = db.Asesor.Find(id);
            db.Asesor.Remove(asesor);
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
