using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01P02_2020GA603.Models
{
    public class Roles
    {
        [Key]
        [Display(Name = "Id de Rol")]
        public int RolId { get; set; }
        [Display(Name = "Rol")]
        public string Rol { get; set; }
    }
}
    