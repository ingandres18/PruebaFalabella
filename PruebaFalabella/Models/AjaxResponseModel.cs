using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaFalabella.Models
{
    public class AjaxResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
    }
}