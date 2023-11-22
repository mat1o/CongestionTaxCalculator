using CongestionTaxCalculator.Domain.Annotations;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class CityTaxHour : BaseEntity
    {
        public int CityId { get; set; }

        [DatetimeRangeAnnotation]
        public DateTime From { get; set; }

        [DatetimeRangeAnnotation]
        public DateTime To { get; set; }

        public float Amount { get; set; }

        public virtual City City{ get; set; }
    }
}
