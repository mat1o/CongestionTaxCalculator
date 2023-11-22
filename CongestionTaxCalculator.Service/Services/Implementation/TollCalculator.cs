using CongestionTaxCalculator.Domain.Context;
using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Service.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CongestionTaxCalculator.Service.Services.Implementation
{
    public class TollCalculator : ITollCalculator
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TollCalculator(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async ValueTask<float> CalculatTollForCity(City city , DateTime date)
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
                if (cityTaxHoure.From < date && date < cityTaxHoure.To)
                    return cityTaxHoure.Amount;

                else return 0.0f;
            }

            return 0.0f;
        }
    }
}
