using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Service.Services.Abstraction
{
    public interface ITollCalculator
    {
        ValueTask<float> CalculatTollForCity(City city, DateTime dateTime);
    }
}
