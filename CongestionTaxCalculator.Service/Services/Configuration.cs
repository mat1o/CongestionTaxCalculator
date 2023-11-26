using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using CongestionTaxCalculator.Service.Services.Abstraction;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CongestionTaxCalculator.Service.Services
{
    public static class Configuration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromAssemblyOf<ITaxService>()
              .AddClasses()
              .AsMatchingInterface()
              .WithScopedLifetime());

            services.Scan(selector => selector.FromCallingAssembly()
            .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRequestHandler<>)))
            .AsMatchingInterface()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsSelf()
            .WithScopedLifetime());

            services.Scan(selector => selector.FromCallingAssembly()
            .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRequest<>)))
            .AsMatchingInterface()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsSelf()
            .WithScopedLifetime());

            return services;
        }
    }
}
