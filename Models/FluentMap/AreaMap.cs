using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("TB_AREA");

            builder.HasKey(a => a.Area_Id);
            builder.Property(a => a.Area_Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.Tamanho)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired();

            builder.HasOne(a => a.Cultura)
                .WithMany(a => a.Areas)
                .HasForeignKey(a => a.Cultura_Id);

            builder.HasOne(a => a.Funcionario)
                .WithMany(a => a.Areas)
                .HasForeignKey(a => a.Maticula_Funcionario);

            //Relacionamento 1:n Cultura
            builder.HasOne<Cultura>(c => c.Cultura)
                .WithMany(c => c.Areas)
                .HasForeignKey(c => c.Cultura_Id);

            //Relacionamento 1:n Area - Funcionario
            builder.HasOne<Funcionario>(f => f.Funcionario)
                .WithMany(f => f.Areas)
                .HasForeignKey(f => f.Maticula_Funcionario);
        }
    }
}
