using System.Linq.Expressions;

namespace CarDealer.Repositorys
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllNotSoldAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}