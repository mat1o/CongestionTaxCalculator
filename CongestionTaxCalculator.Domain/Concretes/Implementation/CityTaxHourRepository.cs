using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using CongestionTaxCalculator.Domain.Context;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Domain.Concretes.Implementation
{
    public class CityTaxHourRepository : GenericRepository<CityTaxHour> , ICityTaxHourRepository
    {
        public CityTaxHourRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
