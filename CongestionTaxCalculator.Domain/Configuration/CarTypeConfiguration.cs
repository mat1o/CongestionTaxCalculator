using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Domain.Configuration
{
    public class CarTollTypeConfiguration : IEntityTypeConfiguration<CarTollType>
    {
        public void Configure(EntityTypeBuilder<CarTollType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x=>x.Cars)
                .WithOne(x=>x.CarTollType)
                .HasForeignKey(x=>x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
