using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InovaX.Database.Mappings
{
    public class PessoaJuridicaMapping : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("InovaX_Tb_PessoaJuridica");

            builder.Property(u => u.CNPJ)
                .IsRequired();

            builder.Property(u => u.NomeFantasia)
                .IsRequired();

            builder.Property(u => u.NaturezaJuridica)
                .IsRequired();

            builder.Property(u => u.Situacao)
                .IsRequired();

        }

    }
}
