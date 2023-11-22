using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Domain.Configuration
{
    public class TaxHourConfiguration : IEntityTypeConfiguration<TaxHour>
    {
        public void Configure(EntityTypeBuilder<TaxHour> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
