using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Domain.Mock
{
    public static class MockCityTaxHour
    {
        public static IEnumerable<CityTaxHour> MockData() =>
            new List<CityTaxHour>()
            {
                new CityTaxHour(){ Amount = 18.0f, From = new TimeOnly(15,30,00) , To = new TimeOnly(16,59,00) , City = new City { Name = "Gothenburg"} },
                new CityTaxHour(){ Amount = 0.0f, From = new TimeOnly(18,30,00) , To = new TimeOnly(05,59,00) , City = new City { Name = "Gothenburg"} },
                new CityTaxHour(){ Amount = 15.5f, From = new TimeOnly(12,30,00) , To = new TimeOnly(13,59,00) , City = new City { Name = "London"} },
                new CityTaxHour(){ Amount = 13.5f, From = new TimeOnly(18,00,00) , To = new TimeOnly(19,15,00) , City = new City { Name = "Paris"} },
            };

    }
}
