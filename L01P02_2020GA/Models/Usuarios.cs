using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P02_2020GA603.Models
{
    public class Usuarios
    {

        [Key]
        [Display(Name = "Id de usuario")]
        public int UsuarioId { get; set; }
        [Required]

        [Display(Name = "Rol")]

        public int RolId { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]

        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Clave")]
        public string Clave { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
    }


}
