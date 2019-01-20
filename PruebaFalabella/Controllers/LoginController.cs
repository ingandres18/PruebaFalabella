using PruebaFalabella.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PruebaFalabella.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult IniciarSesion(LoginModel model)
        {
            if (!ModelState.IsValid)
                return Json(GetAjaxModel(false, "Complete todos los campos"), JsonRequestBehavior.AllowGet);

            if (!ValidarUsuario(model.NombreUsuario, model.Clave))
                return Json(GetAjaxModel(false, "El usuario o la clave son invalidos"), JsonRequestBehavior.AllowGet);

            CrearCookieAutorizacion(model.NombreUsuario);
            return Json(GetAjaxModel(true, string.Empty, Url.RouteUrl("Home")), JsonRequestBehavior.AllowGet);
        }

        private bool ValidarUsuario(string nombreUsuario, string clave)
        {
            var ctx = new FalabellaContext();
            var usr = ctx.Asesor.Where(x => x.Correo.Equals(nombreUsuario)).SingleOrDefault();

            if (usr == null)
                return false;

            return usr.Clave.Equals(clave);
        }

        private void CrearCookieAutorizacion(string nombreUsuario)
        {
            FormsAuthentication.SetAuthCookie(nombreUsuario, false);

            var authTicket = new FormsAuthenticationTicket(1, nombreUsuario, DateTime.Now,
                DateTime.Now.AddDays(1), false, string.Empty);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }
    }
}