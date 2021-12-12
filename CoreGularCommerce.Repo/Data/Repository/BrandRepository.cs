using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreGularCommerce.Repo.Data.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly StoreContext _context;
        public BrandRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Brand>> GetAllAsync() => await _context.Brands.ToListAsync();

        public async Task<Brand> GetByIdAsync(int id) => await _context.Brands.FindAsync(id);
    }
}