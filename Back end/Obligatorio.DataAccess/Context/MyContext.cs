﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Obligatorio.DataAccess.Context
{
    public class MyContext : DbContext
    {
        public DbSet<TouristSpot> TouristSpots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TouristSpotCategory> TouristSpotCategories { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<ImageWrapper> ImageWrappers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public MyContext() { }
        public MyContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
            .HasMany(r => r.TouristSpots)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Accommodation>()
            .HasMany(a => a.Images)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TouristSpotCategory>()
            .HasKey(tsc => new { tsc.TouristSpotId, tsc.CategoryId });
            modelBuilder.Entity<TouristSpotCategory>()
                .HasOne(tsc => tsc.TouristSpot)
                .WithMany(ts => ts.TouristSpotCategories)
                .HasForeignKey(tsc => tsc.TouristSpotId);
            modelBuilder.Entity<TouristSpotCategory>()
                .HasOne(tsc => tsc.Category)
                .WithMany(c => c.TouristSpotCategories)
                .HasForeignKey(tsc => tsc.CategoryId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();
                var connectionString = configuration.GetConnectionString(@"Obligatorio1Db");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}