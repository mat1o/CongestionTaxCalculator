using CongestionTaxCalculator.Service.Services.Abstraction;
using CongestionTaxCalculator.Service.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace CongestionTaxCalculator.Service.Services
{
    public static class Configuration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();

            return services;
        }
    }
}
