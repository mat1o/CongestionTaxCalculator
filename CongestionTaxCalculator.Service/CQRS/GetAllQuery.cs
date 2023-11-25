using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class GetAllQuery<T> : IRequest<IEnumerable<T>> where T : class
    {
    }
}
