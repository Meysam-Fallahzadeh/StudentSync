using Microsoft.EntityFrameworkCore;
using StudentSync.Domain.Common;
using StudentSync.Contracts.Common;

namespace StudentSync.Data.Ef.Common;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    protected SchoolDbContext SchoolDbContext;
    protected DbSet<TEntity> EntitySet;

    public BaseRepository(SchoolDbContext schoolDbContext)
    {
        SchoolDbContext = schoolDbContext;
        EntitySet = schoolDbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await EntitySet.AddAsync(entity);
        
        await SchoolDbContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await EntitySet.AddRangeAsync(entities);
        
        await SchoolDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        EntitySet.Remove(entity);

        await SchoolDbContext.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        EntitySet.RemoveRange(entities);

        await SchoolDbContext.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsNoTrackingAsync()
    {
        return await EntitySet.AsNoTracking().ToListAsync();
    }

    public async Task<List<TEntity>> GetListAsync()
    {
        return await EntitySet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsNoTrackingAsync(TKey id)
    {
        return await EntitySet.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await EntitySet.FirstOrDefaultAsync(e => e.Id.Equals(id));

    }

    public async Task UpdateAsync(TEntity entity)
    {
        EntitySet.Update(entity);

        await SchoolDbContext.SaveChangesAsync(); 
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        EntitySet.UpdateRange(entities);
       
        await SchoolDbContext.SaveChangesAsync();
    }
}
