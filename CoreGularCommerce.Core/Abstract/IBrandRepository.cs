using CoreGularCommerce.Core.Entities;

namespace CoreGularCommerce.Core.Abstract
{
    public interface IBrandRepository
    {
        Task<Brand> GetByIdAsync(int id);
        Task<IReadOnlyList<Brand>> GetAllAsync();
    }
}