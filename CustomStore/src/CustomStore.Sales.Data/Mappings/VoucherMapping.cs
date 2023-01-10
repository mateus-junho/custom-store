using CustomStore.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomStore.Sales.Data.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Percentage)
                .HasColumnType("decimal(1,4)");

            builder.Property(c => c.DiscountValue)
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Quantity)
                .IsRequired();

            builder.Property(c => c.VoucherDiscountType)
                .IsRequired();

            builder.Property(c => c.UtilizationDate);

            builder.Property(c => c.ValidDate)
                .IsRequired();

            builder.Property(c => c.Active)
                .IsRequired();

            builder.Property(c => c.Used)
                .IsRequired();

            // 1 : N => Voucher : Orders
            builder.HasMany(c => c.Orders)
                .WithOne(c => c.Voucher)
                .HasForeignKey(c => c.VoucherId);

            builder.ToTable("Vouchers");
        }
    }
}
