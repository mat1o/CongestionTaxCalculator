using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Domain.Enum;

namespace CongestionTaxCalculator.Service.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public int CarTypeId { get; set; }

        public CarTollType CarTollType { get; set; }

        public string? LicensePlate { get; set; }

        public bool IsTollFree { get; set; }

        public virtual ICollection<CarCruceLog> TaxLogs { get; set; }

        public virtual ICollection<CarTollType> CarTypes { get; set; }
    }
}
