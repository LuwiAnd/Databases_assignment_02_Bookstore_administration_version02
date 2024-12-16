using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class StockBalanceEntityTypeConfiguration : IEntityTypeConfiguration<StockBalance>
{
    public void Configure(EntityTypeBuilder<StockBalance> builder)
    {
        builder.HasKey(e => new { e.StoreId, e.Isbn13 }).HasName("PK__stockBal__3D186FD3CFEF22D0");

        builder.ToTable("stockBalance");

        builder.Property(e => e.StoreId).HasColumnName("storeID");
        builder.Property(e => e.Isbn13)
            .HasMaxLength(14)
            .HasColumnName("ISBN13");

        builder.HasOne(d => d.Isbn13Navigation).WithMany(p => p.StockBalances)
            .HasForeignKey(d => d.Isbn13)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__stockBala__ISBN1__2FA4FD58");

        builder.HasOne(d => d.Store).WithMany(p => p.StockBalances)
            .HasForeignKey(d => d.StoreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__stockBala__store__2EB0D91F");
    }
}
