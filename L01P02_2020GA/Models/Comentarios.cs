using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P02_2020GA603.Models
{

    public class Comentarios
    {
        [Key]
        [Display(Name = "Id de comentario")]

        public int ComentarioId { get; set; }

        [Display(Name = "Id de publicacion")]

        public int PublicacionId { get; set; }
        [Display(Name = "Comentario")]

        public string Comentario { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }

}
