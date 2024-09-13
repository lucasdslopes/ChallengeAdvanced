using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired().HasColumnType("varchar(255)"); ;

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Senha)
                .IsRequired();
        }
    }
}
