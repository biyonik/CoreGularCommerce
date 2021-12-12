using CoreGularCommerce.Core.Entities;

namespace CoreGularCommerce.Core.Abstract
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
    }
}