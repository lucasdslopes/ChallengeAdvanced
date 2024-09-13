using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("InovaX_Tb_Endereco");

            builder.HasKey(e => e.IdEndereco); 

            builder.Property(u => u.CEP)
                .IsRequired();

            builder.Property(u => u.Rua)
                .IsRequired();

            builder.Property(u => u.Complemento);

            builder.Property(u => u.Bairro)
                .IsRequired();

            builder.Property(u => u.Estado)
                .IsRequired();
 
            builder.Property(u => u.Numero) 
                .IsRequired();

            builder.Property(u => u.Cidade)
                .IsRequired();
        }
    }
}
