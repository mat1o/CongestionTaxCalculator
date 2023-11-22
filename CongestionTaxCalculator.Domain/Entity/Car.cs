using CongestionTaxCalculator.Domain.Enum;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class Car : BaseEntity
    {
        public int CarTypeId { get; set; }

        public CarTollType CarTollType { get; set; }

        public string? LicensePlate { get; set; }

        public bool IsTollFree { get; set; }

        public virtual ICollection<CarCruceLog> TaxLogs { get; set; }

        public virtual ICollection<CarTollType> CarTypes { get; set; }
    }
}
