using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class CombateMap : IEntityTypeConfiguration<Combate>
    {
        public void Configure(EntityTypeBuilder<Combate> builder)
        {
            builder.ToTable("TB_COMBATE");

            builder.HasKey(ap => new { ap.Agro_Id, ap.Praga_Id });

            builder.Property(c => c.Agro_Id)
                .ValueGeneratedNever();

            builder.Property(c => c.Praga_Id)
                .ValueGeneratedNever();

            //Relacionamentos 1:n
            builder.HasOne(c => c.Agrotoxico)
                .WithMany(c => c.Combates)
                .HasForeignKey(c => c.Agro_Id);

            builder.HasOne(c => c.Praga)
                .WithMany(c => c.Combates)
                .HasForeignKey(c => c.Praga_Id);
        }
    }
}
