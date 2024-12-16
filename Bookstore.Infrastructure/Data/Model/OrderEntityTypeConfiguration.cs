using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.OrderId).HasName("PK__orders__C3905BAFB5150BCF");

        builder.ToTable("orders");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.CustomerBirthDate).HasColumnName("customerBirthDate");
        builder.Property(e => e.CustomerPnrLastFourDigits)
            .HasMaxLength(4)
            .HasColumnName("customerPnrLastFourDigits");
        builder.Property(e => e.Status).HasMaxLength(30);
        builder.Property(e => e.StoreId).HasColumnName("storeID");

        builder.HasOne(d => d.Store).WithMany(p => p.Orders)
            .HasForeignKey(d => d.StoreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__orders__storeID__3A228BCB");

        builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
            .HasForeignKey(d => new { d.CustomerBirthDate, d.CustomerPnrLastFourDigits })
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__orders__392E6792");
    }
}
