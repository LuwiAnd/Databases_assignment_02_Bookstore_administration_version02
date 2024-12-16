using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class TitlesPerAuthorEntityTypeConfiguration : IEntityTypeConfiguration<TitlesPerAuthor>
{
    public void Configure(EntityTypeBuilder<TitlesPerAuthor> builder)
    {
        builder
            .HasNoKey()
            .ToView("TitlesPerAuthor");

        builder.Property(e => e.FullName).HasMaxLength(201);
        builder.Property(e => e.TotalStockValue).HasColumnType("decimal(38, 2)");
    }
}
