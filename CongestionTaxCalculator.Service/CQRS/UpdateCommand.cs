using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class UpdateCommand<T> : IRequest<T> where T : class
    {
        public T Object { get; set; }
    }
}
