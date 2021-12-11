using CoreGularCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreGularCommerce.Repo.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}