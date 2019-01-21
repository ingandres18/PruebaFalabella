using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PruebaFalabella.Models
{
    public class GenVenta
    {
        public int Id { get; set; }

        public string EmailAsesor { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int NoDocumento { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required]
        public string PrimerApellido { get; set; }

        [Required]
        public string SegundoApellido { get; set; }

        public int Cantidad { get; set; }

        [Required]
        public int Valor { get; set; }

        [DisplayName("Productos")]
        public List<SelectListItem> Productos { get; set; }
    }
}