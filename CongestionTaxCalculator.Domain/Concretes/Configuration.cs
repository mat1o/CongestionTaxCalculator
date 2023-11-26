using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CongestionTaxCalculator.Domain.Concretes
{
    public static class Configuration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<ICityTaxHourRepository>()
                .AddClasses()
                .AsMatchingInterface()
                .WithScopedLifetime());

            return services;
        }
    }
}
