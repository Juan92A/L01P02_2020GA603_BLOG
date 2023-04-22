using L01P02_2020GA603.Models;
using Microsoft.EntityFrameworkCore;

namespace L01P02_2020GA603.Data
{
    public class blogDBContext : DbContext
    {

        public blogDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Publicaciones> publicaciones { get; set; }
        public DbSet<Comentarios> comentarios { get; set; }
        public DbSet<Calificaciones> calificaciones { get; set; }

    }
}
