using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreGularCommerce.Repo.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync() => await _context.Products.Include(p => p.Brand).Include(p => p.ProductType).ToListAsync();

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.Include(p => p.Brand).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == id);
    }
}