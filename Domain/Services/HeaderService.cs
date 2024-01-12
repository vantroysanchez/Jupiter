using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IHeaderRepository _repository;

        public HeaderService(IHeaderRepository headerRepository)
        {
            _repository = headerRepository;
        }

        public async Task Remove(Header header, CancellationToken cancellationToken = default)
        {
            await _repository.Remove(header, cancellationToken);

        }

        public IQueryable<Header> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IQueryable<Header>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Header> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Add(Header entity, CancellationToken cancellationToken = default)
        {
            await _repository.Add(entity, cancellationToken);
        }

        public async Task Update(Header entity, CancellationToken cancellationToken = default)
        {
            await _repository.Update(entity, cancellationToken);
        }

        public async Task<IEnumerable<Header>> GetWhere(Expression<Func<Header, bool>> predicate)
        {
            return await _repository.GetWhere(predicate);
        }
    }
}
