using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaFalabella.Models
{
    [Table("Ventas")]
    public class Venta
    {

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Asesor Asesor { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public int Valor { get; set; }

    }
}