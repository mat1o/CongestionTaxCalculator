namespace CongestionTaxCalculator.Domain.Entity
{
    public class CarCruceLog : BaseEntity
    {
        public int CarId { get; set; }

        public DateTime EventDatetime { get; set; }

        public string? MyProperty { get; set; }

        public Car Car { get; set; }
    }
}
