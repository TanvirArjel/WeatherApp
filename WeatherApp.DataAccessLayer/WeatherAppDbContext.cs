using Microsoft.EntityFrameworkCore;
using System;
using WeatherApp.Models;

namespace WeatherApp.DataAccessLayer
{
    public class WeatherAppDbContext : DbContext
    {
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options) : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<WeatherUpdate> WeatherUpdates { get; set; }
        public DbSet<LatestUpdate> LatestUpdates { get; set; }
    }
}
