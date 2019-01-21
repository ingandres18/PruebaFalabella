using PruebaFalabella.Models;
using PruebaFalabella.Servicios;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PruebaFalabella.Controllers
{
    public class GenVentasController : Controller
    {
        private FalabellaContext db = new FalabellaContext();
        private VentasRepository ventas = new VentasRepository();
        private AsesorRepository _asesorRepository;

        // GET: GenVentas
        public ActionResult Index()
        {
            _asesorRepository = new AsesorRepository();
            return View(ventas.ObtenerVentas());
        }

        // GET: GenVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenVenta genVenta = db.GenVentas.Find(id);
            if (genVenta == null)
            {
                return HttpNotFound();
            }
            return View(genVenta);
        }

        // GET: GenVentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailAsesor,IdProducto,NoDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Cantidad,Valor")] GenVenta genVenta)
        {
            if (ModelState.IsValid)
            {
                db.GenVentas.Add(genVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genVenta);
        }

        // GET: GenVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenVenta genVenta = db.GenVentas.Find(id);
            if (genVenta == null)
            {
                return HttpNotFound();
            }
            return View(genVenta);
        }

        // POST: GenVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailAsesor,IdProducto,NoDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Cantidad,Valor")] GenVenta genVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genVenta);
        }

        // GET: GenVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenVenta genVenta = db.GenVentas.Find(id);
            if (genVenta == null)
            {
                return HttpNotFound();
            }
            return View(genVenta);
        }

        // POST: GenVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenVenta genVenta = db.GenVentas.Find(id);
            db.GenVentas.Remove(genVenta);
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