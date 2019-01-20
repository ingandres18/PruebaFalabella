using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFalabella.Models
{
    [Table("Productos")]
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public virtual Compania Compania { get; set; }
    }
}