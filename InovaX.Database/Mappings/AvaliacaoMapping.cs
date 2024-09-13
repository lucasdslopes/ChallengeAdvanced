using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class AvaliacaoMapping : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.ToTable("InovaX_Tb_Avaliacao");

            builder.HasKey(u => u.IdAvaliacao);

            builder.Property(u => u.DataAvaliacao)
                .IsRequired();

            builder.Property(u => u.Texto)
                .IsRequired();
        }

    }
}
