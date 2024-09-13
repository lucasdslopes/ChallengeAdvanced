using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InovaX.Database.Mappings
{
     public class DistribuidorMapping : IEntityTypeConfiguration<Distribuidor>
    {
        public void Configure(EntityTypeBuilder<Distribuidor> builder)
        {
            builder.ToTable("InovaX_Tb_Distribuidor");

            builder.Property(u => u.Tipo)
                .IsRequired();
        }

    }
}
