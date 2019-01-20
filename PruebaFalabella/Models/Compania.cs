using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaFalabella.Models
{
    public class Compania
    {
        public Compania()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Ciudad { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}