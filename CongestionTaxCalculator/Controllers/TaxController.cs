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

        [HttpGet]
        public async ValueTask<float> GetTax(GetTaxViewModel getTaxViewModel) => await _taxService.GetTax(getTaxViewModel);


        //a sample of insert a record in citytaxhour table via mediatR service(CQRS).
        [HttpPut]
        public async Task<CityTaxHour> InsertNewCityTaxHour(CityTaxHourViewModel cityTaxHourViewModel)
            => await _mediatior.Send(new CreateCommand<CityTaxHour>() { Object = cityTaxHourViewModel.MapToMainModel<CityTaxHour,CityTaxHourViewModel>() });
        
    }
}
