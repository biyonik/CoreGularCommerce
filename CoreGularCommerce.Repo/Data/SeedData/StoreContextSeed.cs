using System.Text.Json;
using CoreGularCommerce.Core.Entities;
using Microsoft.Extensions.Logging;

namespace CoreGularCommerce.Repo.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory) {
            try {
                if(!context.Brands.Any()) {
                    var brandsData = await File.ReadAllTextAsync("../CoreGularCommerce.Repo/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
                    await context.Brands.AddRangeAsync(brands.ToArray());
                    await context.SaveChangesAsync();
                }
                if(!context.ProductTypes.Any()) {
                    var productTypeData = await File.ReadAllTextAsync("../CoreGularCommerce.Repo/Data/SeedData/types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                    await context.ProductTypes.AddRangeAsync(productTypes.ToArray());
                    await context.SaveChangesAsync();
                }
                if(!context.Products.Any()) {
                    var productsData = await File.ReadAllTextAsync("../CoreGularCommerce.Repo/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    await context.Products.AddRangeAsync(products.ToArray());
                    await context.SaveChangesAsync();
                }
            } catch(Exception ex) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}