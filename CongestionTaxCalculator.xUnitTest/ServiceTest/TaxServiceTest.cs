using CongestionTaxCalculator.Service.Services.Abstraction;
using CongestionTaxCalculator.Service.ViewModels;
using System;

namespace CongestionTaxCalculator.xUnitTest.ServiceTest
{
    public class TaxServiceTest
    {
        private readonly ITollService _tollService;

        public static IEnumerable<object[]> SplitCountData =>
        new List<object[]>
        {
            new object[] { new CityViewModel { Name = "Gothenburg" }, new TimeOnly(16,00,00) , 18.0f }, //true
            new object[] { new CityViewModel { Name = "Berlin" }, new TimeOnly(15,00,00) , 18.0f }, //fasls. Berlin's toll data is not available.
            new object[] { new CityViewModel { Name = "Gothenburg" }, new TimeOnly(21,30,00) , 12.20f }, // false. during 18:30 to 05:59 toll is free.
        };

        public TaxServiceTest(ITollService tollService)
        {
            _tollService = tollService;
        }


        [Theory, MemberData(nameof(SplitCountData))]
        public void CalculateToll(CityViewModel city, TimeOnly time, float expectedToll)
        {
            var toll = _tollService.CalculatTollForTest(city, time);

            Assert.Equal(toll, expectedToll);
        }
    }
}
