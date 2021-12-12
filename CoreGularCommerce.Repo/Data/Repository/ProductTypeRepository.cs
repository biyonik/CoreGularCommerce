using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreGularCommerce.Repo.Data.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly StoreContext _context;
        public ProductTypeRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<ProductType>> GetAllAsync() => await _context.ProductTypes.ToListAsync();

        public async Task<ProductType> GetByIdAsync(int id) => await _context.ProductTypes.FindAsync(id);
    }
}