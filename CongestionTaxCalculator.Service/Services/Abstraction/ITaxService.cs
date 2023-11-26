using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Service.ViewModels;

namespace CongestionTaxCalculator.Service.Services.Abstraction
{
    public interface ITaxService
    {
        ValueTask<float> GetTax(GetTaxViewModel getTaxViewModel);
        ValueTask<float> GetTollFee(CarViewModel vehicle, DateTime date, CityViewModel city);
    }
}
