using CustomStore.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomStore.Sales.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .HasDefaultValueSql("NEXT VALUE FOR MySequence");

            builder.Property(c => c.ClientId)
                .IsRequired();

            builder.Property(c => c.VoucherId);

            builder.Property(c => c.VoucherApplied)
                .IsRequired();

            builder.Property(c => c.Discount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.TotalValue)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.OrderStatus);

            builder.HasMany(c => c.OrderItems)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderId);

            builder.ToTable("Orders");
        }
    }
}
