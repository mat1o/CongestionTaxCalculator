namespace CongestionTaxCalculator.Domain.Entity
{
    public class CityTaxHour : BaseEntity
    {
        public int CityId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public float Amount { get; set; }

        public virtual City City{ get; set; }
    }
}
