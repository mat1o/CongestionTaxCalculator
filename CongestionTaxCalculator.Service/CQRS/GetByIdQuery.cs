using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class GetByIdQuery<T> : IRequest<T> where T : class
    {
        public long Id { get; set; }
    }
}
