using PruebaFalabella.Servicios.Autenticacion;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace PruebaFalabella
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegistrarInyeccionDependencias();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static void RegistrarInyeccionDependencias()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Register<IServicioAutenticacion, ServicioAutenticacion>(Lifestyle.Scoped);

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}