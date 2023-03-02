using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Audit
    {
        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task Add(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Remove(T entity, CancellationToken cancellationToken);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
