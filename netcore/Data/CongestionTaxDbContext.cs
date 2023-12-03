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
        public DbSet<TollTaxRule> TaxRules { get; set; }

   
        public CongestionTaxDbContext(DbContextOptions<CongestionTaxDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CongestionTaxDbContext).Assembly);
        }
    }

}
