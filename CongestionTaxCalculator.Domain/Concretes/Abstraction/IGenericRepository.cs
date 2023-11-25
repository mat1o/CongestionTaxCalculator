using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.Concretes.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task DeatachAsync(TEntity entityToDeatach);
        int Delete(object id);
        void Delete(TEntity entityToDelete);
        Task<int> DeleteRangeAsync(Func<TEntity, bool> predicatToDelete);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool needTracking = true);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool needTracking = true, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool needTracking = true);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool needTracking = true, params Expression<Func<TEntity, object>>[] includes);
        TEntity GetByID(object id);
        Task<TEntity> GetByIDAsync(object id, CancellationToken ct);
        int Insert(TEntity entity);
        Task<int> InsertAsync(TEntity entity);
        int InsertRange(IEnumerable<TEntity> entities);
        Task<int> InsertRangeAsync(IEnumerable<TEntity> entities);
        //Task<TEntity> LastOrDefaultAsync();
        //Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        int Update(TEntity entityToUpdate);
        Task<int> UpdateAsync(TEntity entityToUpdate, EntityState entityState = EntityState.Modified);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entitiesToUpdate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties, bool needTracking = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
