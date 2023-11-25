using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Service.ViewModels;

namespace CongestionTaxCalculator.Service.Services.Abstraction
{
    public interface ITollService
    {
        ValueTask<float> CalculatTollForCity(CityViewModel city, DateTime dateTime);
    }
}
