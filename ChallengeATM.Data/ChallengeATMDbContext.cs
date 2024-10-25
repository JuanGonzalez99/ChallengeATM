using ChallengeATM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeATM.Data
{
    public class ChallengeATMDbContext(DbContextOptions<ChallengeATMDbContext> options) : DbContext(options)
    {
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
