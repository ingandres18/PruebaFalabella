using PruebaFalabella.Models;
using PruebaFalabella.Servicios.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PruebaFalabella.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IServicioAutenticacion servicioAutenticacion;

        public LoginController(IServicioAutenticacion servicioAutenticacion)
        {
            this.servicioAutenticacion = servicioAutenticacion;
        }

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

            var retorno = servicioAutenticacion.Autenticar(model.NombreUsuario, model.Clave);
            if (!retorno.Exito)
                return Json(GetAjaxModel(false, retorno.Mensaje), JsonRequestBehavior.AllowGet);

            CrearCookieAutorizacion(model.NombreUsuario);
            return Json(GetAjaxModel(true, string.Empty, Url.RouteUrl("Home")), JsonRequestBehavior.AllowGet);
        }

        private void CrearCookieAutorizacion(string userName)
        {
            FormsAuthentication.SetAuthCookie(userName, false);

            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now,
                DateTime.Now.AddDays(1), false, string.Empty);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }

    }
}