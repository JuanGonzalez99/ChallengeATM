namespace ChallengeATM.Data.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        Task<List<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
