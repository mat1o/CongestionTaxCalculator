using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Service.ViewModels;

namespace CongestionTaxCalculator.Service.Services.Abstraction
{
    public interface ITaxService
    {
        ValueTask<float> GetTax(CarViewModel vehicle, CityViewModel city);
        ValueTask<float> GetTollFee(CarViewModel vehicle, DateTime date, CityViewModel city);
    }
}
