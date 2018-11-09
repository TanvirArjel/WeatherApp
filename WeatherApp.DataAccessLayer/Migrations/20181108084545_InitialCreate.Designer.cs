﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.DataAccessLayer;

namespace WeatherApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(WeatherAppDbContext))]
    [Migration("20181108084545_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApp.Models.Location", b =>
                {
                    b.Property<long>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Distance");

                    b.Property<string>("LatLong");

                    b.Property<string>("LocationType");

                    b.Property<string>("Title");

                    b.Property<long>("WoeId");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WeatherApp.Models.WeatherUpdate", b =>
                {
                    b.Property<long>("WeatherUpdateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AirPressure");

                    b.Property<DateTime>("ApplicableDate");

                    b.Property<decimal>("CurrentTemp");

                    b.Property<float>("Humidity");

                    b.Property<long>("LocationId");

                    b.Property<decimal>("MaxTemp");

                    b.Property<decimal>("MinTemp");

                    b.Property<float>("Predictability");

                    b.Property<float>("Visibility");

                    b.Property<string>("WeatherStateAbbr");

                    b.Property<string>("WeatherStateName");

                    b.Property<string>("WindDirection");

                    b.Property<string>("WindDirectionCompass");

                    b.Property<float>("WindSpeed");

                    b.HasKey("WeatherUpdateId");

                    b.HasIndex("LocationId");

                    b.ToTable("WeatherUpdates");
                });

            modelBuilder.Entity("WeatherApp.Models.WeatherUpdate", b =>
                {
                    b.HasOne("WeatherApp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
