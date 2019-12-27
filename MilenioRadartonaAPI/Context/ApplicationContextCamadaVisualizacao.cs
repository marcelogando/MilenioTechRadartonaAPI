using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Models.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Context
{
    public class ApplicationContextCamadaVizualizacao : DbContext
    {
        public ApplicationContextCamadaVizualizacao(DbContextOptions<ApplicationContextCamadaVizualizacao> options)
        : base(options)
        {
        }

        public DbSet<LocalizacaoRadares> LocalizacaoRadares { get; set; }
        public DbSet<RadaresTipoEnquadramento> RadaresTipoEnquadramento { get; set; }
        public DbSet<RadaresLote> RadaresZonaConcessao { get; set; }
        public DbSet<FluxoVeiculosRadares> FluxoVeiculosRadares { get; set; }
        public DbSet<TipoVeiculosRadares> TipoVeiculosRadares { get; set; }
        public DbSet<InfracoesRadares> InfracoesRadares { get; set; }
        public DbSet<AcuraciaIdentificacaoRadares> AcuraciaIdentificacaoRadares { get; set; }
        public DbSet<PerfilVelocidadesRadar> PerfilVelocidadesRadar { get; set; }
        public DbSet<Models.Trajetos> Trajetos { get; set; }
        public DbSet<VelocidadeMediaTrajeto> VelocidadeMediaTrajeto { get; set; }
        public DbSet<Models.Viagens> Viagens { get; set; }
        public DbSet<DistanciaViagem> DistanciaViagem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalizacaoRadares>().HasKey(k => k.Id);
            modelBuilder.Entity<RadaresTipoEnquadramento>().HasKey(k => k.Id);
            modelBuilder.Entity<RadaresLote>().HasKey(k => k.Id);
            modelBuilder.Entity<FluxoVeiculosRadares>().HasKey(k => k.Id);
            modelBuilder.Entity<TipoVeiculosRadares>().HasKey(k => k.Id);
            modelBuilder.Entity<InfracoesRadares>().HasKey(k => k.Id);
            modelBuilder.Entity<AcuraciaIdentificacaoRadares>().HasKey(k => k.Id);
            modelBuilder.Entity<PerfilVelocidadesRadar>().HasKey(k => k.Id);
            modelBuilder.Entity<Models.Trajetos>().HasKey(k => k.Id);
            modelBuilder.Entity<VelocidadeMediaTrajeto>().HasKey(k => k.Id);
            modelBuilder.Entity<Models.Viagens>().HasKey(k => k.Id);
            modelBuilder.Entity<DistanciaViagem>().HasKey(k => k.Id);



        }





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


    }
}
