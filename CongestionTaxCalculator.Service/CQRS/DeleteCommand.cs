using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class DeleteCommand<T> : IRequest<bool> where T : class
    {
        public long Id { get; set; }
    }
}
