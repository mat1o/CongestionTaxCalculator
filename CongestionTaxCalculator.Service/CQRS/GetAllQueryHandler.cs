using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class GetAllQueryHandler<T> : IRequestHandler<GetAllQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GetAllQueryHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> Handle(GetAllQuery<T> request, CancellationToken cancellationToken)
        => await _repository.GetAsync();
    }
}
