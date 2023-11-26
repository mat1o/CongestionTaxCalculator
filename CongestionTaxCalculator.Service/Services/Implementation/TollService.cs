using CongestionTaxCalculator.Domain.Context;
using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Domain.Mock;
using CongestionTaxCalculator.Service.Services.Abstraction;
using CongestionTaxCalculator.Service.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Service.Services.Implementation
{
    public class TollService : ITollService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TollService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async ValueTask<float> CalculatTollForCity(CityViewModel city , DateTime date)
        {
            var cityTaxHours = await _applicationDbContext.CityTaxHours
                .Include(x=>x.City)
                .Where(x=>x.CityId == city.Id)
                .ToListAsync();

            return FindTollAmount(city,new TimeOnly(date.Hour,date.Minute,date.Second), cityTaxHours);
        }

        public float CalculatTollForTest(CityViewModel city, TimeOnly time) => FindTollAmount(city, time, MockCityTaxHour.MockData());
        
        private float FindTollAmount(CityViewModel city, TimeOnly time, IEnumerable<CityTaxHour> cityTaxHours)
        {
            foreach (var cityTaxHoure in cityTaxHours)
            {
                if(cityTaxHoure.City.Name == city.Name)
                if (time.CompareTo(cityTaxHoure.From) > 0 && time.CompareTo(cityTaxHoure.To) < 0)
                    return cityTaxHoure.Amount;

                else return 0.0f;
            }

            return 0.0f;
        }
    }
}
