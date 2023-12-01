﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using congestion.calculator.Data;

namespace congestion.calculator.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("congestion.calculator.Data.TimeInterval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TimeIntervals");
                });

            modelBuilder.Entity("congestion.calculator.Data.TollFreeDate", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.HasKey("Date");

                    b.ToTable("TollFreeDates");
                });

            modelBuilder.Entity("congestion.calculator.Data.TollFreeVehicle", b =>
                {
                    b.Property<string>("Vehicle")
                        .HasColumnType("TEXT");

                    b.HasKey("Vehicle");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}