using CongestionTaxCalculator.Domain.Enum;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class Car : BaseEntity
    {
        public CarType CarType { get; set; }
        public string? LicensePlate { get; set; }

        public virtual ICollection<TaxLog> TaxLogs { get; set; }
    }
}
