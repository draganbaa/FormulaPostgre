using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaPostgreSql.Models;
using Microsoft.EntityFrameworkCore;


namespace FormulaPostgreSql.Data
{
    public class FormulaPostgreSqlContext : DbContext
    {
        public FormulaPostgreSqlContext (DbContextOptions<FormulaPostgreSqlContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<LocationInfo> LocationInfos { get; set; }
        public DbSet<TrackInfo> TrackInfos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<QualifyingResult> QualifyingResults { get; set; }
        public DbSet<ImageInfo> ImageInfos { get; set; }
    }
}
