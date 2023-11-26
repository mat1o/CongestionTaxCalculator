using CongestionTaxCalculator.Service.Services.Abstraction;
using CongestionTaxCalculator.Service.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CongestionTaxCalculator.xUnitTest.ServiceTest
{
    
    public class TaxServiceTest : IClassFixture<ServiceFixture>
    {
        private ServiceProvider _serviceProvider;

        public TaxServiceTest(ServiceFixture serviceFixture)
        {
            _serviceProvider = serviceFixture.ServiceProvider;
        }

        public static IEnumerable<object[]> SplitCountData =>
        new List<object[]>
        {
            new object[] { new CityViewModel { Name = "Gothenburg" }, new TimeOnly(16,00,00) , 18.0f }, //true
            new object[] { new CityViewModel { Name = "Berlin" }, new TimeOnly(15,00,00) , 18.0f }, //false. Berlin's toll data is not available.
            new object[] { new CityViewModel { Name = "Gothenburg" }, new TimeOnly(21,30,00) , 12.20f }, // false. during 18:30 to 05:59 toll is free.
            new object[] { new CityViewModel { Name = "London" }, new TimeOnly(13, 00, 00), 15.5f }, // true.
        };

        [Theory, MemberData(nameof(SplitCountData))]
        public void CalculateToll(CityViewModel city, TimeOnly time, float expectedToll)
        {
            var tollService = _serviceProvider.GetService<ITollService>();

            var toll = tollService?.CalculatTollForTest(city,time);

            Assert.Equal(toll, expectedToll);
        }
    }
}
