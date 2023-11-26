using CongestionTaxCalculator.Domain.Context;
using CongestionTaxCalculator.Service.Services.Abstraction;
using CongestionTaxCalculator.Service.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CongestionTaxCalculator.xUnitTest
{
    public class ServiceFixture
    {
        public ServiceFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(""), ServiceLifetime.Scoped);

            serviceCollection.AddScoped<ITollService, TollService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

        }

        public ServiceProvider ServiceProvider { get; set; }
    }
}
