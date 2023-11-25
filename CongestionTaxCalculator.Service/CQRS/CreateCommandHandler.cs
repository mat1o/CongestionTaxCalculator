using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using MediatR;

namespace CongestionTaxCalculator.Service.CQRS
{
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public CreateCommandHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.InsertAsync(request?.Object) > 0 ? request?.Object : null;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
