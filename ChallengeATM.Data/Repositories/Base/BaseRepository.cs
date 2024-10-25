using Microsoft.EntityFrameworkCore;

namespace ChallengeATM.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity>(ChallengeATMDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ChallengeATMDbContext _dbContext = dbContext;
        private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
        
        public static async Task<(List<TItem> items, int cantidadTotal)> GetPaginatedAsync<TItem>(IQueryable<TItem> baseQuery, int skip, int take, CancellationToken cancellationToken)
        {
            var cantidadTotal = await baseQuery.CountAsync(cancellationToken);

            var operaciones = await baseQuery
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

            return (operaciones, cantidadTotal);
        }
    }
}
