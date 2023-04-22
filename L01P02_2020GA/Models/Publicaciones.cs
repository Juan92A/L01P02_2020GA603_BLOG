using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P02_2020GA603.Models
{

    public class Publicaciones
    {
        [Key]
        [Display(Name = "ID de publicación")]
        public int PublicacionId { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Id de usuario")]
        
        public int UsuarioId { get; set; }
    }

}
