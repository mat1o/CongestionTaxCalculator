using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Service.Services.Abstraction
{
    public interface ITaxCalculatorService
    {
        ValueTask<float> GetTax(Car vehicle, City city);
        ValueTask<float> GetTollFee(Car vehicle, DateTime date, City city);
    }
}
