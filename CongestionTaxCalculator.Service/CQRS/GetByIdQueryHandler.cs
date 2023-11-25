using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class GetByIdQueryHandler<T> : IRequestHandler<GetByIdQuery<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GetByIdQueryHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
         => await _repository.GetByIDAsync(request.Id, cancellationToken);
    }
}
