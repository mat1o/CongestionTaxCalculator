using CongestionTaxCalculator.Domain.Concretes.Abstraction;
using CongestionTaxCalculator.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.Concretes.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool needTracking = true)
        {
            return needTracking ? await dbSet.FirstOrDefaultAsync(predicate: predicate) :
                  await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate: predicate);
        }


        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool needTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            if (includes.Any())
                query = includes.Aggregate(query, (current, expression) => current.Include(expression));

            return needTracking ? await query.FirstOrDefaultAsync(predicate: predicate) :
                  await query.AsNoTracking().FirstOrDefaultAsync(predicate: predicate);
        }


        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties, bool needTracking = true)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return needTracking ? await query.FirstOrDefaultAsync(predicate: predicate) :
                  await query.AsNoTracking().FirstOrDefaultAsync(predicate: predicate);
        }

        //public virtual async Task<TEntity> LastOrDefaultAsync()
        //{
        //    Expression<Func<TEntity, long>> keySelector = x => x.Id;
        //    return await dbSet.OrderByDescending(keySelector).FirstOrDefaultAsync();
        //}

        //public virtual async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        //{
        //    return await dbSet.OrderByDescending(x => x.Id).FirstOrDefaultAsync(predicate);
        //}

        public virtual IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return dbSet.Select(selector);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">use a lambda expression to filter the collection, this is optional</param>
        /// <param name="orderBy">select a field from entity using lambda expression for collection to being filter form</param>
        /// <param name="includeProperties">use th name of the property of entity to bieng included in returned</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool needTracking = true)
        {
            IQueryable<TEntity> query = needTracking ? dbSet : dbSet.AsNoTracking();

            if (filter != null)
            {
                query = needTracking ? query.Where(filter) : query.AsNoTracking().Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = needTracking ? query.Include(includeProperty)
                    : query.Include(includeProperty).AsNoTracking();
            }

            if (orderBy != null)
            {
                return needTracking ? await orderBy(query).ToListAsync()
                    : await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return needTracking ? await query.ToListAsync()
                    : await query.AsNoTracking().ToListAsync();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        bool needTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {


            IQueryable<TEntity> query = needTracking ? dbSet : dbSet.AsNoTracking();

            if (filter != null)
            {
                query = needTracking ? query.Where(filter) : query.AsNoTracking().Where(filter);
            }

            if (includes.Any())
                query = includes.Aggregate(query, (current, expression) => current.Include(expression));

            if (orderBy != null)
            {
                return needTracking ? await orderBy(query).ToListAsync()
                    : await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return needTracking ? await query.ToListAsync()
                    : await query.AsNoTracking().ToListAsync();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIDAsync(object id, CancellationToken ct)
        {
            return await dbSet.FindAsync(id, ct);
        }


        public virtual int Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return _context.SaveChanges();
        }


        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public virtual int InsertRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
            return SaveChanges();
        }

        public virtual async Task<int> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }

        public virtual int Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            return _context.SaveChanges();
        }

        public virtual async Task<int> DeleteRangeAsync(Func<TEntity, bool> predicatToDelete)
        {
            var entityToDelete = dbSet.Where(predicatToDelete);
            dbSet.RemoveRange(entityToDelete);
            return await SaveChangesAsync();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual int Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public virtual async Task<int> UpdateAsync(TEntity entityToUpdate, EntityState entityState = EntityState.Modified)
        {
            dbSet.Attach(entityToUpdate).State = entityState;
            _context.Entry(entityToUpdate).State = entityState;
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entitiesToUpdate)
        {
            //dbSet.AttachRange(entitiesToUpdate);
            //  _context.Entry(entitiesToUpdate).State = EntityState.Modified;
            dbSet.UpdateRange(entitiesToUpdate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task DeatachAsync(TEntity entityToDeatach)
        {
            _context.Entry(entityToDeatach).State = EntityState.Detached;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate is null) return await dbSet.AnyAsync();

            return await dbSet.AnyAsync(predicate);

        }
    }
}
