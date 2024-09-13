using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("InovaX_Tb_Servico");

            builder.HasKey(u => u.IdServico);

            builder.Property(u => u.Nome)
                .IsRequired();

            builder.Property(u => u.Descricao)
                .IsRequired();
            
            builder.Property(u => u.Preco)
                .IsRequired();
        }
    }
}
