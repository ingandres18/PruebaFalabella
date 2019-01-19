using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PruebaFalabella.Controllers
{
    public class CerrarSesionController : Controller
    {

        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect(Url.RouteUrl("Login"));
        }
    }
}