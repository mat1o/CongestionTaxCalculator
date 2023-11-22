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
        public virtual DbSet<TaxHour> TaxHours { get; set; }
        public virtual DbSet<TaxLog> TaxLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
        }
    }
}
