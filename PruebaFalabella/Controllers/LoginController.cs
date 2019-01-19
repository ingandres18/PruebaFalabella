using PruebaFalabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return Json(GetAjaxModel(false, "Implementar :("), JsonRequestBehavior.AllowGet);
        }
    }
}