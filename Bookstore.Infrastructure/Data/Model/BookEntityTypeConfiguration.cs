using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.Isbn13).HasName("PK__books__3BF79E03D5D3DDBC");

        builder.ToTable("books");

        builder.Property(e => e.Isbn13)
            .HasMaxLength(14)
            .HasColumnName("ISBN13");
        builder.Property(e => e.CurrentPrice).HasColumnType("decimal(7, 2)");
        builder.Property(e => e.Genre).HasMaxLength(100);
        builder.Property(e => e.Language).HasMaxLength(100);
        builder.Property(e => e.Title).HasMaxLength(100);
    }
}
