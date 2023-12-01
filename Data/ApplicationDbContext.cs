//using System;
//using System.Data.Entity;
using congestion.calculator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace congestion.calculator.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TollFreeDate> TollFreeDates { get; set; }
        public DbSet<TollFreeVehicle> TollFreeVehicles { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TollFreeDate>()
            .HasKey(x => x.Date);
            modelBuilder.Entity<TollFreeVehicle>()
            .HasKey(x => x.Vehicle);
            modelBuilder.Entity<TimeInterval>()
                .HasKey(x => x.Id);
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("Data Source=c:\\mydb.db;Version=3;New=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
