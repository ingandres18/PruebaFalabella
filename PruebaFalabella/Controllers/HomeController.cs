using PruebaFalabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaFalabella.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var usr = HttpContext.User.Identity.Name;

            //var vta = new Venta();
            //vta.Asesor = GetAsesorPorCorreo(HttpContext.User.Identity.Name);
            //vta.Producto = GetProductoPorId(model.IdProducto);

            //var ctx = new FalabellaContext();
            //ctx.Venta.Add(vta);
            //ctx.SaveChanges();

            //ctx.Asesor.Where(x => x.Correo.ToLower().Equals("")).SingleOrDefault();

            //var prod = ctx.Producto.FirstOrDefault();
            //var nam = prod.Compania.Descripcion;

            //var prod2 = ctx.Producto.Where(x => x.Id == 1 && !string.IsNullOrEmpty(x.Descripcion));
            //var tst = prod2.ToList();

            return View();
        }
    }
}