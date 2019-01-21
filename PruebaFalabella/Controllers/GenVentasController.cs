using PruebaFalabella.Models;
using PruebaFalabella.Servicios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PruebaFalabella.Controllers
{
    public class GenVentasController : BaseController
    {
        private VentasRepository ventas = new VentasRepository();
        private ProductosRepository prods = new ProductosRepository();
        private ClienteRepository clientes = new ClienteRepository();

        // GET: GenVentas
        public ActionResult Index()
        {
            return View(ventas.ObtenerVentas());
        }

        private GenVenta ObtenerModelo(int? Id)
        {
            var objVentas = Id.HasValue ? ventas.ObtenerPorId(Id.Value) : new GenVenta();
            objVentas.Productos = new List<SelectListItem>();

            foreach (var item in prods.ObtenerProductos())
            {
                objVentas.Productos.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.Id.ToString()
                });
            }

            return objVentas;
        }

        // GET: GenVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            GenVenta genVenta = ventas.ObtenerPorId(id.Value);
            if (genVenta == null)
                return HttpNotFound();

            return View(genVenta);
        }

        // GET: GenVentas/Create
        public ActionResult Create()
        {
            return View(ObtenerModelo(null));
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
                genVenta.EmailAsesor = HttpContext.User.Identity.Name;
                ventas.Crear(genVenta);
                return RedirectToAction("Index");
            }

            return View(genVenta);
        }

        // GET: GenVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            GenVenta genVenta = ventas.ObtenerPorId(id.Value);
            if (genVenta == null)
                return HttpNotFound();

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
                return RedirectToAction("Index");
            }
            return View(genVenta);
        }

        // GET: GenVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            GenVenta genVenta = ventas.ObtenerPorId(id.Value);
            if (genVenta == null)
                return HttpNotFound();

            return View(genVenta);
        }

        // POST: GenVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ventas.Eliminar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ConsultarCliente(string idCliente)
        {
            int id;
            if (!int.TryParse(idCliente, out id))
                return Json(GetAjaxModel(false, "Numero de id invalido"), JsonRequestBehavior.AllowGet);

            var cliente = clientes.ObtenerPorId(int.Parse(idCliente));
            if (cliente == null)
                return Json(GetAjaxModel(true, ""), JsonRequestBehavior.AllowGet);

            return Json(GetAjaxModel(true,
                $"{cliente.PrimerNombre}|{cliente.SegundoNombre}|{cliente.PrimerApelldo}|{cliente.SegundoApellido}"), JsonRequestBehavior.AllowGet);
        }
    }
}