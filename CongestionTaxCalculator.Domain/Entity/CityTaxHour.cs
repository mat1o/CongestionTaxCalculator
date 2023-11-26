using CongestionTaxCalculator.Domain.Annotations;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class CityTaxHour : BaseEntity
    {
        public int CityId { get; set; }

        public TimeOnly From { get; set; }

        public TimeOnly To { get; set; }

        public float Amount { get; set; }

        public virtual City City{ get; set; }
    }
}
