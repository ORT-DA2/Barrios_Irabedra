﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Obligatorio.DataAccess.Context
{
    public class MyContext : DbContext
    {
        public DbSet<TouristSpot> touristSpots { get; set; }
        public MyContext() { }
        public MyContext(DbContextOptions options) : base(options) { }

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
