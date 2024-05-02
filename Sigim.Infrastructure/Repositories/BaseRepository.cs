using Complii.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Sigim.Domain.common;
using Sigim.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigim.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly SigimDbContext _context;

        public BaseRepository(SigimDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(List<Expression<Func<T, object>>> includes = null, Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (filter != null) query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<string>? includeString = null,
                                       bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includeString != null && includeString.Count > 0) query = includeString.Aggregate(query, (current, path) => current.Include(path));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();


            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     List<Expression<Func<T, object>>> includes = null,
                                     bool disableTracking = true)
        {

            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();


            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddListEntity(ICollection<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void UpdateEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void DeleteList(ICollection<T> list)
        {
            _context.Set<T>().RemoveRange(list);
        }
        public void DetachEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
