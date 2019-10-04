using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class CulturaMap : IEntityTypeConfiguration<Cultura>
    {
        public void Configure(EntityTypeBuilder<Cultura> builder)
        {
            builder.ToTable("TB_CULTURA");

            builder.HasKey(c => c.Cultura_Id);

            builder.Property(c => c.Cultura_Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Mes_Inicio)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Mes_Fim)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.TempoMaximo)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
