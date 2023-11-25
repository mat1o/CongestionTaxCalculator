using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommand<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public UpdateCommandHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        => await _repository.UpdateAsync(request.Object) > 0 ? request.Object : null;
    }
}
