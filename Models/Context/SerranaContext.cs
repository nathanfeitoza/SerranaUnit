using Hangfire.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models.Context
{
    public class SerranaContext : DbContext
    {
        public SerranaContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentMap.AplicacaoAgrotoxicoMap());
            modelBuilder.ApplyConfiguration(new FluentMap.AgrotoxicoMap());
            modelBuilder.ApplyConfiguration(new FluentMap.AreaMap());
            modelBuilder.ApplyConfiguration(new FluentMap.AtaqueMap());
            modelBuilder.ApplyConfiguration(new FluentMap.CombateMap());
            modelBuilder.ApplyConfiguration(new FluentMap.CulturaMap());
            modelBuilder.ApplyConfiguration(new FluentMap.FuncionarioMap());
            modelBuilder.ApplyConfiguration(new FluentMap.PragaMap());
        }

        public DbSet<AplicacaoAgrotoxico> AplicacaoAgrotoxicos { get; set; }

        public DbSet<Agrotoxico> Agrotoxico { get; set; }

        public DbSet<Area> Area { get; set; }

        public DbSet<Ataque> Ataque { get; set; }

        public DbSet<Combate> Combate { get; set; }

        public DbSet<Cultura> Cultura { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        public DbSet<Praga> Praga { get; set; }
    }
}
