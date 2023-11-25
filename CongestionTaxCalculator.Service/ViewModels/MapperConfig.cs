using AutoMapper;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Service.ViewModels
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Car, CarViewModel>());

            return new Mapper(config);
        }
    }
}
