using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PruebaFalabella
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "iniciar-sesion",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "CerrarSesion",
                url: "cerrar-sesion",
                defaults: new { controller = "CerrarSesion", action = "Index" }
            );

            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
