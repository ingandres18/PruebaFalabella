using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFalabella.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            Ventas = new HashSet<Venta>();
        }

        public int Id { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required]
        public string PrimerApelldo { get; set; }

        public string SegundoApellido { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}