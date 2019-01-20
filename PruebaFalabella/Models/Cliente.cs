using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFalabella.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required]
        public string PrimerApelldo { get; set; }

        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
    }
}