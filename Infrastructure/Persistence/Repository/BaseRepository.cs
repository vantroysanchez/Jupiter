using Domain.Common;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using LinqKit;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Audit
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {  
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task Update(T entity, CancellationToken cancellationToken = default)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task Remove(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        
        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().CountAsync(predicate);
    }
}
