using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Keskhinne.Models;

namespace Keskhinne.Data
{
    public class KeskhinneContext : DbContext
    {
        public KeskhinneContext (DbContextOptions<KeskhinneContext> options)
            : base(options)
        {
        }

        public DbSet<Hinne> Hinded { get; set; }
        public DbSet<AineHinne> Ainetehinded { get; set; }
        public DbSet<Aine> Ained { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Aine>().ToTable("Aine");
            modelBuilder.Entity<Hinne>().ToTable("Hinne");
            modelBuilder.Entity<AineHinne>().ToTable("AineHinne");
            modelBuilder.Entity<AineHinne>().HasIndex(ah => ah.AineID).IsUnique();
        }
    }
}
