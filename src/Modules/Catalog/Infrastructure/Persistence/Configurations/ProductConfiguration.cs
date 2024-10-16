
using ModularMonolithShop.Catalog.Domain.Entities;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Configurations;


public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "catalog");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(100);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.LastModifiedAt).IsRequired(false);
    }
}