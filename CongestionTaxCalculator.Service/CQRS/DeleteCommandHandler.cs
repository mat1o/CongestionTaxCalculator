using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>, bool> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public DeleteCommandHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        => _repository.Delete(request.Id) > 0;
    }
}
