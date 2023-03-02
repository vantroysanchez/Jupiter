using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task Add(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Remove(T entity, CancellationToken cancellationToken);
    }
}
