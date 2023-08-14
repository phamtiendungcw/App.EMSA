using EMSA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSA.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "product");
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(250);
            builder.HasIndex(x => x.ProductName).IsUnique();
            builder.Property(x => x.WholeSalePrice).HasPrecision(18, 2);
            builder.Property(x => x.SalePrice).HasPrecision(18, 2);
            builder.Property(x => x.ImportPrice).HasPrecision(18, 2);
        }
    }
}
