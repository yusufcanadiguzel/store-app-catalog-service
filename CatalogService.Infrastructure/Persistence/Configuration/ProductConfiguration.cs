using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Tabak Seti", Description = "12 Parça Porselen Tabak Seti", Price = 1000.00m, UnitsInStock = 100, IsActive = true },
                new Product { Id = 2, Name = "Kahve Fincanı", Description = "6 Parça Fincan Seti", Price = 799.99m, UnitsInStock = 50, IsActive = true },
                new Product { Id = 3, Name = "Bulaşık Makinesi", Description = "3 Programlı Bulaşık Makinesi", Price = 8000.00m, UnitsInStock = 20, IsActive = true }
            );
        }
    }
}
