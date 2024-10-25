using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeATM.Data.Entities.Mappings
{
    internal class TarjetaMapping : IEntityTypeConfiguration<Tarjeta>
    {
        public void Configure(EntityTypeBuilder<Tarjeta> builder)
        {
            builder.ToTable("OPERACION");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.NumeroTarjeta)
                .HasColumnName("NUMERO_TARJETA")
                .IsRequired();

            builder.Property(t => t.Pin)
                .HasColumnName("PIN")
                .IsRequired();

            builder.Property(t => t.CuentaId)
                .HasColumnName("CUENTA_ID")
                .IsRequired();

            builder.Property(t => t.UsuarioId)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            builder.Property(t => t.FechaUltimaExtraccion)
                .HasColumnName("ULTIMA_EXTRACCION")
                .IsRequired();

            builder.Property(t => t.IntentosFallidos)
                .HasColumnName("INTENTOS_FALLIDOS")
                .IsRequired();

            builder.Property(t => t.EstaBloqueada)
                .HasColumnName("ESTA_BLOQUEADA")
                .IsRequired();

            builder.HasOne(t => t.Cuenta)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
