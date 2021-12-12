using CoreGularCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreGularCommerce.Repo.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImagePath).IsRequired();

            builder.HasOne(b => b.Brand).WithMany().HasForeignKey(p => p.BrandId);
            builder.HasOne(b => b.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
    }
}