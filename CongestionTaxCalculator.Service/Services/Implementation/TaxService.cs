using CongestionTaxCalculator.Domain.Context;
using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Service.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Service.Utilities;
using CongestionTaxCalculator.Service.ViewModels;

namespace CongestionTaxCalculator.Service.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ITollService _tollCalculator;

        public TaxService(ApplicationDbContext applicationDbContext,
            ITollService tollCalculator)
        {
            _applicationDbContext = applicationDbContext;
            _tollCalculator = tollCalculator;
        }

        public async ValueTask<float> GetTax(CarViewModel vehicle , CityViewModel city)
        {
            var carCruceLogs = await _applicationDbContext.CarCruceLogs
                .Where(q => q.CarId == vehicle.Id)
                .OrderBy(q=>q.EventDatetime)
                .ToListAsync();

            float totalFee = 0f;
            var intervalStart = carCruceLogs.FirstOrDefault().EventDatetime;

            carCruceLogs.ForEach(async c =>
            {
                var nextFee = await GetTollFee(vehicle, c.EventDatetime,city);
                var tempFee = await GetTollFee(vehicle, intervalStart, city);

                long diffInMillies = c.EventDatetime.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                    totalFee += nextFee;

            });
            if (totalFee > 60) totalFee = 60;
            return totalFee;

        }

        public async ValueTask<float> GetTollFee(CarViewModel vehicle, DateTime date, CityViewModel city)
            => date.IsTollFreeDate() || vehicle.IsTollFreeVehicle() ? 0.0f : await _tollCalculator.CalculatTollForCity(city,date);
    }
}
