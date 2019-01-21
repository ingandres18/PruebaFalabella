using System.ComponentModel.DataAnnotations;

namespace PruebaFalabella.Models
{
    public class LoginModel
    {
        [Display(Name = "Correo Asesor")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Este campo es requerido")]
        [MaxLength(40, ErrorMessage = "La longitud maxima es de 40")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Clave del usuario")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
    }
}