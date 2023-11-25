using CongestionTaxCalculator.Domain.Context;
using CongestionTaxCalculator.Domain.Entity;
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

            return FindAmountToll(date, cityTaxHours);
        }

        private float FindAmountToll(DateTime date, IEnumerable<CityTaxHour> cityTaxHours)
        {
            foreach (var cityTaxHoure in cityTaxHours)
            {
                if (DateTime.Compare(cityTaxHoure.From, date) == -1 && DateTime.Compare(date, cityTaxHoure.To) == -1)
                    return cityTaxHoure.Amount;

                else return 0.0f;
            }

            return 0.0f;
        }
    }
}
