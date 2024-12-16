using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(e => e.StoreId).HasName("PK__stores__1EA716332EE43517");

        builder.ToTable("stores");

        builder.Property(e => e.StoreId).HasColumnName("storeID");
        builder.Property(e => e.Country).HasMaxLength(100);
        builder.Property(e => e.District).HasMaxLength(100);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Phone).HasMaxLength(30);
        builder.Property(e => e.Street).HasMaxLength(100);
    }
}
