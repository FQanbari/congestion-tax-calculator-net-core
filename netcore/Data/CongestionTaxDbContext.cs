using congestion.calculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Data
{
    public class CongestionTaxDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<TollRate> TollRates { get; set; }
        public DbSet<TollFreeDate> TollFreeDates { get; set; }
        public DbSet<TollFreeVehicle> ExemptVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TaxRule> TaxRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection here
            optionsBuilder.UseSqlite("Data Source=database.db;Version=3;New=True;Compress=True;");
        }
    }

}
