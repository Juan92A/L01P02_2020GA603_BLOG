using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01P02_2020GA603.Models
{
    public class Calificaciones
    {
        [Key]
        public int CalificacionId { get; set; }
        [Required]
        public int PublicacionId { get; set; }

        [Required]

        public int UsuarioId { get; set; }
        [Required]

        public int Calificacion { get; set; }
    }
}
