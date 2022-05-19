using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;

namespace BaseRead.Models
{
    public partial class CricketContext : DbContext
    {
        public CricketContext()
        {
        }

        public CricketContext(DbContextOptions<CricketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Matches> Matches { get; set; } = null!;
        public virtual DbSet<Players> Players { get; set; } = null!;
        public virtual DbSet<Season2021> Season2021 { get; set; } = null!;
        public virtual DbSet<Season2022> Season2022 { get; set; } = null!;
        public virtual DbSet<Seasons> Seasons { get; set; } = null!;

        private string DbPath = @"Assets\cricket.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directoryPath = Directory.GetCurrentDirectory();
                directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
                DbPath = directoryPath + DbPath;
                optionsBuilder.UseSqlite("Data source=" + DbPath);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.Match);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.FullName);
            });

            modelBuilder.Entity<Season2021>(entity =>
            {
                entity.HasKey(e => e.Match);
            });

            modelBuilder.Entity<Season2022>(entity =>
            {
                entity.HasKey(e => e.Match);
            });

            modelBuilder.Entity<Seasons>(entity =>
            {
                entity.HasKey(e => e.Year);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
