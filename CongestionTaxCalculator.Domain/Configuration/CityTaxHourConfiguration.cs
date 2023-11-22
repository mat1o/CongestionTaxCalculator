using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Domain.Configuration
{
    public class CityTaxHourConfiguration : IEntityTypeConfiguration<CityTaxHour>
    {
        public void Configure(EntityTypeBuilder<CityTaxHour> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(x=>x.City)
                .WithMany(x=>x.CityTaxHours)
                .HasForeignKey(x=>x.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
