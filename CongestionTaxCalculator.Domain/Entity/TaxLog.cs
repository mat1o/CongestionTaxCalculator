namespace CongestionTaxCalculator.Domain.Entity
{
    public class TaxLog : BaseEntity
    {
        public int CarId { get; set; }

        public string? MyProperty { get; set; }

        public Car Car { get; set; }
    }
}
