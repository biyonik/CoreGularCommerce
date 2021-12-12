using CoreGularCommerce.Core.Specification.Abstract;

namespace CoreGularCommerce.Core.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity: class, IEntity, new()
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetEntityWithSpecificationAsync(ISpecification<TEntity> specification);
        Task<IReadOnlyList<TEntity>> GetEntitiesWithSpecificationAsync(ISpecification<TEntity> specification);
        Task<int> CountAsync(ISpecification<TEntity> specification);
    }
}