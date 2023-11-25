using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Service.CQRS;
using CongestionTaxCalculator.Service.Services.Abstraction;
using CongestionTaxCalculator.Service.Utilities;
using CongestionTaxCalculator.Service.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;
        private readonly IMediator _mediatior;

        public TaxController(ITaxService taxService,
            IMediator mediatior)
        {
            _taxService = taxService;
            _mediatior = mediatior;
        }

        public async ValueTask<float> GetTax(CarViewModel vehicle, CityViewModel city) => await _taxService.GetTax(vehicle, city);

        public async Task<CityTaxHour> InsertNewCityTaxHour(CityTaxHourViewModel cityTaxHourViewModel)
            => await _mediatior.Send(new CreateCommand<CityTaxHour>() { Object = cityTaxHourViewModel.MapToMainModel<CityTaxHour,CityTaxHourViewModel>() });
        
    }
}
