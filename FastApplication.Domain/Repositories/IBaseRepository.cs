public interface IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    Task<TEntity> GetByIdAsync(TKey id);
    Task<List<TEntity>> GetAllAsync();
    Task <TEntity> InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
}
