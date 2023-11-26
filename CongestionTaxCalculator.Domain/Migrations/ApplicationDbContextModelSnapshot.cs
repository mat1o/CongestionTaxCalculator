﻿// <auto-generated />
using System;
using CongestionTaxCalculator.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CongestionTaxCalculator.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("IsTollFree")
                        .HasColumnType("bit");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlate")
                        .IsUnique()
                        .HasFilter("[LicensePlate] IS NOT NULL");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CarCruceLog", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CarCruceLogs");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CarTollType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("TollFree")
                        .HasColumnType("bit");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarTollTypes");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CityTaxHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<TimeSpan>("From")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("To")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CityTaxHours");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.Car", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entity.CarTollType", "CarTollType")
                        .WithMany("Cars")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CarTollType");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CarCruceLog", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entity.Car", "Car")
                        .WithMany("TaxLogs")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CarTollType", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entity.Car", null)
                        .WithMany("CarTypes")
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CityTaxHour", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entity.City", "City")
                        .WithMany("CityTaxHours")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.Car", b =>
                {
                    b.Navigation("CarTypes");

                    b.Navigation("TaxLogs");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.CarTollType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entity.City", b =>
                {
                    b.Navigation("CityTaxHours");
                });
#pragma warning restore 612, 618
        }
    }
}
