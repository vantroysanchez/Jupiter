using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class DetailService : IDetailService
    {
        private readonly IDetailRepository _repository;

        public DetailService(IDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Remove(Detail detail, CancellationToken cancellationToken = default)
        {            
            await _repository.Remove(detail, cancellationToken);
            
        }

        public IQueryable<Detail> GetAll()
        {
            return _repository.GetAll();            
        }

        public async Task<Detail> GetById(int id)
        {
            return await _repository.GetById(id);            
        }

        public async Task Add(Detail entity, CancellationToken cancellationToken = default)
        {
            await _repository.Add(entity, cancellationToken);            
        }        

        public async Task Update(Detail entity, CancellationToken cancellationToken = default)
        {
            await _repository.Update(entity, cancellationToken);            
        }

        public async Task<IEnumerable<Detail>> GetWhere(Expression<Func<Detail, bool>> predicate)
        {
            return await _repository.GetWhere(predicate);
        }

    }
}
