using Microsoft.EntityFrameworkCore;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Models.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Context
{
    public class PostgresContext : DbContext
    {

        public PostgresContext (DbContextOptions<PostgresContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<BaseRadares> BaseRadares { get; set; }
        public DbSet<Models.Postgres.Viagens> Viagens { get; set; }
        public DbSet<Contagens> Contagens { get; set; }
        public DbSet<Models.Postgres.Trajetos> Trajetos { get; set; }
        public DbSet<WazeAlerts> WazeAlerts { get; set; }
        public DbSet<WazeJams> WazeJams { get; set; }


    }
}
