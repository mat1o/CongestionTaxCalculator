using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Domain.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x=>x.CityTaxHours)
                .WithOne(x => x.City)
                .HasForeignKey(x=>x.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
