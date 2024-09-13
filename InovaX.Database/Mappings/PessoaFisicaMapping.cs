using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("InovaX_Tb_PessoaFisica");


            builder.Property(u => u.CPF)
                .IsRequired();

            builder.Property(u => u.RG)
                .IsRequired();
        }

    }
}
