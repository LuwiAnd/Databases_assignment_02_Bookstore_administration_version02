using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
            builder.HasKey(e => new { e.OrderId, e.Isbn13 }).HasName("PK__orderDet__2BB64A9DC39D26EA");

            builder.ToTable("orderDetails");

            builder.Property(e => e.OrderId).HasColumnName("orderID");
            builder.Property(e => e.Isbn13)
                .HasMaxLength(14)
                .HasColumnName("ISBN13");
            builder.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");
            builder.Property(e => e.Price).HasColumnType("decimal(7, 2)");

            builder.HasOne(d => d.Isbn13Navigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Isbn13)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderDeta__ISBN1__40CF895A");

            builder.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderDeta__order__3FDB6521");
    }
}
