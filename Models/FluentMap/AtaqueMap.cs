using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class AtaqueMap : IEntityTypeConfiguration<Ataque>
    {
        public void Configure(EntityTypeBuilder<Ataque> builder)
        {
            builder.ToTable("TB_ATAQUE");

            builder.HasKey(cp => new { cp.Cultura_Id, cp.Praga_Id });

            builder.Property(a => a.Cultura_Id)
                .ValueGeneratedNever();

            builder.Property(a => a.Praga_Id)
                .ValueGeneratedNever();

            //Relacionamentos 1:n
            builder.HasOne(a => a.Cultura)
                .WithMany(a => a.Ataques)
                .HasForeignKey(a => a.Cultura_Id);

            builder.HasOne(a => a.Praga)
                .WithMany(a => a.Ataques)
                .HasForeignKey(a => a.Praga_Id);
        }
    }
}
