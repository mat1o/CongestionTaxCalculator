namespace CongestionTaxCalculator.Domain.Entity
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<CityTaxHour> CityTaxHours { get; set; }
    }
}
