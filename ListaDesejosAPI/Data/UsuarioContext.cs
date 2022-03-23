using Baseline.ImTools;
using ImTools;
using ListaDesejosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDesejosAPI.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> opt) : base (opt) {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Desejo>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Desejos)
                .HasForeignKey(x => x.UsuarioId);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Desejo> Desejos { get; set; }
        
    }
}
