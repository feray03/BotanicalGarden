using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{ 
    public class GardenContext : DbContext
    {
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Tree> Trees { get; set; }
        public virtual DbSet<Shrub> Shrubs { get; set; }
        public virtual DbSet<Cactus> Cactuses { get; set; }
        public virtual DbSet<Grass> Grasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>()
                .HasMany(p => p.Flowers)
                .WithOne(b => b.Seasons)
                .HasForeignKey(b => b.SeasonsId);
           
            modelBuilder.Entity<Season>()
                .HasMany(p => p.Trees)
                .WithOne(b => b.Seasons)
                .HasForeignKey(b => b.SeasonsId);
            
            modelBuilder.Entity<Season>()
                .HasMany(p => p.Shrubs)
                .WithOne(b => b.Seasons)
                .HasForeignKey(b => b.SeasonsId);
            
            modelBuilder.Entity<Season>()
                .HasMany(p => p.Cactuses)
                .WithOne(b => b.Seasons)
                .HasForeignKey(b => b.SeasonsId);
            
            modelBuilder.Entity<Season>()
                .HasMany(p => p.Grasses)
                .WithOne(b => b.Seasons)
                .HasForeignKey(b => b.SeasonsId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database = BotanicalGarden; Integrated Security = true ");
        }
    }
}
