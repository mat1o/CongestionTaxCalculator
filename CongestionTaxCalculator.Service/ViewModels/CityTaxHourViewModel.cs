using CongestionTaxCalculator.Domain.Annotations;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Service.ViewModels
{
    public class CityTaxHourViewModel
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        [DatetimeRangeAnnotation]
        public DateTime From { get; set; }

        [DatetimeRangeAnnotation]
        public DateTime To { get; set; }

        public float Amount { get; set; }

        public City City { get; set; }
    }
}
