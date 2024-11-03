using StudentSync.Domain.Common;

namespace StudentSync.Contracts.Common;

public interface IBaseRepository<TEntity,in TKey> 
    where TEntity : BaseEntity<TKey>
    where TKey:IEquatable<TKey>
{
    Task<List<TEntity>> GetListAsync();
    
    Task<List<TEntity>> GetAllAsNoTrackingAsync();
    
    Task<TEntity> GetByIdAsync(TKey id);
    
    Task<TEntity> GetByIdAsNoTrackingAsync(TKey id);
    
    Task AddAsync(TEntity entity);
    
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    
    Task UpdateAsync(TEntity entity);
    
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    
    Task DeleteAsync(TEntity entity);
    
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    

}
