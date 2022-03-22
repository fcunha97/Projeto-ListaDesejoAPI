using Baseline.ImTools;
using ImTools;
using Microsoft.EntityFrameworkCore;

namespace ListaDesejosAPI.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> opt) : base (opt) {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
