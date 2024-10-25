using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeATM.Data.Entities.Mappings
{
    public class CuentaMapping : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("CUENTA");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.NumeroCuenta)
                .HasColumnName("NUMERO_CUENTA")
                .IsRequired();

            builder.Property(c => c.Saldo)
                .HasColumnName("SALDO")
                .IsRequired();
        }
    }
}
