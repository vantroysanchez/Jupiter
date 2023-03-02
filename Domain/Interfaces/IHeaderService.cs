using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IHeaderService
    {
        IQueryable<Header> GetAll();
        Task<IEnumerable<Header>> GetWhere(Expression<Func<Header, bool>> predicate);
        Task<Header> GetById(int id);
        Task Add(Header entity, CancellationToken cancellationToken = default);
        Task Update(Header entity, CancellationToken cancellationToken = default);
        Task Remove(Header detail, CancellationToken cancellationToken = default);
    }
}