using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class AgrotoxicoMap : IEntityTypeConfiguration<Agrotoxico>
    {
        public void Configure(EntityTypeBuilder<Agrotoxico> builder)
        {
            builder.ToTable("TB_AGROTOXICO");

            builder.HasKey(a => a.Agro_Id);

            builder.Property(a => a.Agro_Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(a => a.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Qtd_Disponivel)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(a => a.Unidade_Medida)
                .HasMaxLength(5)
                .IsRequired();
        }
    }
}
