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
        public virtual DbSet<Season_year> Season_year { get; set; } = null!;
        public virtual DbSet<Seasons> Seasons { get; set; } = null!;
        public virtual DbSet<Teams> Teams { get; set; } = null!;

        private string DbPath = @"Assets\cricket.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directoryPath = Directory.GetCurrentDirectory();
                directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
                DbPath = directoryPath + DbPath;
                optionsBuilder.UseSqlite("Data source=" + DbPath + ";Foreign Keys=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.Match);
                entity.HasOne(d => d.PlayersIdNavigation)
                .WithMany(p => p.MatchesIdNavigation)
                .HasForeignKey(d => d.Player_of_match);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.FullName);
            });

            modelBuilder.Entity<Season_year>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.SeasonsIdNavigation)
                .WithMany(p => p.Season_yearIdNavigation)
                .HasForeignKey(d => d.Date_month_day);
            });
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.PlayersIdNavigation)
                .WithMany(p => p.TeamsIdNavigation)
                .HasForeignKey(d => d.Players);

                entity.HasOne(d => d.MatchesIdNavigation)
                .WithMany(p => p.TeamsIdNavigation)
                .HasForeignKey(d => d.Match);
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
