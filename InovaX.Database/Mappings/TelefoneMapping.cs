using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("InovaX_Tb_Telefone");

            builder.HasKey(u => u.TelefoneId);

            builder.Property(u => u.DDI)
                .IsRequired();

            builder.Property(u => u.DDD)
                .IsRequired();

            builder.Property(u => u.Numero)
                .IsRequired();
        }
    }
}
