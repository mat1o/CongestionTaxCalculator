using CongestionTaxCalculator.Domain.Configuration;
using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Domain.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarCruceLog> CarCruceLogs { get; set; }
        public virtual DbSet<CarTollType> CarTollTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CityTaxHour> CityTaxHours { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
        }
    }
}
