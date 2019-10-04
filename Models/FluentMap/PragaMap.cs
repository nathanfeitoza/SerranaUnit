using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class PragaMap : IEntityTypeConfiguration<Praga>
    {
        public void Configure(EntityTypeBuilder<Praga> builder)
        {
            builder.ToTable("TB_PRAGA");

            builder.HasKey(p => p.Praga_Id);

            builder.Property(p => p.Praga_Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(p => p.Nome_Popular)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Nome_Cientifico)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Estacao)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
