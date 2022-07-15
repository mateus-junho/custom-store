using CustomStore.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomStore.Catalog.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).IsRequired();

            builder.Property(b => b.Description).IsRequired();

            builder.Property(b => b.Active).IsRequired();

            builder.Property(b => b.Price).IsRequired();

            builder.Property(b => b.Image);

            builder.Property(b => b.Quantity).IsRequired();

            builder.OwnsOne(b => b.Dimensions, d =>
            {
                d.Property(x => x.Height)
                    .HasColumnName("Height")
                    .HasColumnType("int");

                d.Property(x => x.Width)
                    .HasColumnName("Width")
                    .HasColumnType("int");

                d.Property(x => x.Depth)
                    .HasColumnName("Depth")
                    .HasColumnType("int");
            });

            builder.Property(b => b.CategoryId).IsRequired();

            builder.ToTable("Products");
        }
    }
}
