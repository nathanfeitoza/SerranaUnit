using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.FluentMap
{
    public class AplicacaoAgrotoxicoMap : IEntityTypeConfiguration<AplicacaoAgrotoxico>
    {
        public void Configure(EntityTypeBuilder<AplicacaoAgrotoxico> builder)
        {
            builder.ToTable("TB_AplicacaoAgrotoxico");

            builder.HasKey(a => new { a.Area_Id, a.Agro_Id });

            builder.Property(a => a.Area_Id)
                .ValueGeneratedNever();

            builder.Property(a => a.Agro_Id)
                .ValueGeneratedNever();

            //Relacionamentos 1:n

            builder.HasOne(a => a.Area)
                .WithMany(a => a.AplicacoesAgrotoxicos)
                .HasForeignKey(a => a.Area_Id);

            builder.HasOne(a => a.Agrotoxico)
                .WithMany(a => a.AplicacoesAgrotoxicos)
                .HasForeignKey(a => a.Agro_Id);
        }
    }
}
