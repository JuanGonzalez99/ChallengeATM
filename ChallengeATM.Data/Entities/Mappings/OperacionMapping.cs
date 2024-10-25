using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeATM.Data.Entities.Mappings
{
    public class OperacionMapping : IEntityTypeConfiguration<Operacion>
    {
        public void Configure(EntityTypeBuilder<Operacion> builder)
        {
            builder.ToTable("OPERACION");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(o => o.TarjetaId)
                .HasColumnName("TARJETA_ID")
                .IsRequired();

            builder.Property(o => o.TipoOperacionCodigo)
                .HasColumnName("TIPO_OPERACION")
                .IsRequired();

            builder.Property(o => o.FechaHoraCreacion)
                .HasColumnName("FECHA_HORA_CREACION")
                .IsRequired();

            builder.Property(o => o.SaldoAnterior)
                .HasColumnName("SALDO_ANTERIOR")
                .IsRequired();

            builder.Property(o => o.Monto)
                .HasColumnName("MONTO")
                .IsRequired();

            builder.Property(o => o.SaldoPosterior)
                .HasColumnName("SALDO_POSTERIOR")
                .IsRequired();

            builder.HasOne(o => o.Tarjeta)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
