using System.ComponentModel.DataAnnotations;

namespace PruebaFalabella.Models
{
    public class LoginModel
    {
        [Display(Name = "Nombre de usuario")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Este campo es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud maxima es de 20")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Clave del usuario")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
    }
}