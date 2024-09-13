using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("InovaX_Tb_Produto");

            builder.HasKey(u => u.IdProduto);

            builder.Property(u => u.Nome)
                .IsRequired();

            builder.Property(u => u.Descricao)
                .IsRequired();

            builder.Property(u => u.Preco)
               .IsRequired();

            builder.Property(u => u.Quantidade)
               .IsRequired();
        }

    }
}
