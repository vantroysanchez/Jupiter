using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IDetailService
    {
        IQueryable<Detail> GetAll();
        Task<IEnumerable<Detail>> GetWhere(Expression<Func<Detail, bool>> predicate);
        Task<Detail> GetById(int id);
        Task Add(Detail entity, CancellationToken cancellationToken = default);
        Task Update(Detail entity, CancellationToken cancellationToken = default);
        Task Remove(Detail detail, CancellationToken cancellationToken = default);
    }
}