using CoreGularCommerce.Core.Entities;

namespace CoreGularCommerce.Core.Abstract
{
    public interface IProductTypeRepository
    {
        Task<ProductType> GetByIdAsync(int id);
        Task<IReadOnlyList<ProductType>> GetAllAsync();
    }
}