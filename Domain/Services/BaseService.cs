using Domain.Common;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : Audit
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }        

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await _repository.Add(entity, cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            await _repository.Update(entity, cancellationToken);
        }

        public async Task Remove(T entity, CancellationToken cancellationToken = default)
        {
            await _repository.Remove(entity, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetWhere(predicate);
        }

    }
}
