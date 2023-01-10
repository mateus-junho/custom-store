using CustomStore.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomStore.Sales.Data.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProductId)
                .IsRequired();

            builder.Property(c => c.ProductName)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(c => c.Order)
                .WithMany(c => c.OrderItems);

            builder.Property(c => c.Quantity)
                .IsRequired();

            builder.Property(c => c.UnitaryValue)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.ToTable("OrderItems");
        }
    }
}
