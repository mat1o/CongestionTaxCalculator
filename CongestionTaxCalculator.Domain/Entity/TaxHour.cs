namespace CongestionTaxCalculator.Domain.Entity
{
    public class TaxHour : BaseEntity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public float Amount { get; set; }
    }
}
