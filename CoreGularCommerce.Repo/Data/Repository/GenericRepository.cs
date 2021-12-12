using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Specification.Abstract;
using CoreGularCommerce.Repo.Data.Drivers;
using Microsoft.EntityFrameworkCore;

namespace CoreGularCommerce.Repo.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(ISpecification<TEntity> specification) => await ApplySpecification(specification).CountAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IReadOnlyList<TEntity>> GetEntitiesWithSpecificationAsync(ISpecification<TEntity> specification) => await ApplySpecification(specification).ToListAsync();

        public async Task<TEntity> GetEntityWithSpecificationAsync(ISpecification<TEntity> specification) => await ApplySpecification(specification).FirstOrDefaultAsync();

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification) => SpecificationDriver<TEntity>.GetQueryable(_context.Set<TEntity>().AsQueryable(), specification);
    }
}