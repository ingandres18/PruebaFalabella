using PruebaFalabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaFalabella.Controllers
{
    public class BaseController : Controller
    {

        protected AjaxResponseModel GetAjaxModel(bool success, string message)
        {
            return GetAjaxModel(success, message, string.Empty);
        }

        protected AjaxResponseModel GetAjaxModel(bool success, string message, string redirUrl)
        {
            return new AjaxResponseModel
            {
                Message = message,
                RedirectUrl = redirUrl,
                Success = success
            };
        }

    }
}