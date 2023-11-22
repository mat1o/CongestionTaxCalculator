using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Domain.Configuration
{
    public class CarCruceLogConfiguration : IEntityTypeConfiguration<CarCruceLog>
    {
        public void Configure(EntityTypeBuilder<CarCruceLog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.TaxLogs)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
