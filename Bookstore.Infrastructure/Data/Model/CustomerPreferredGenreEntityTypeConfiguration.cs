using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class CustomerPreferredGenreEntityTypeConfiguration : IEntityTypeConfiguration<CustomerPreferredGenre>
{
    public void Configure(EntityTypeBuilder<CustomerPreferredGenre> builder)
    {
        builder
            .HasNoKey()
            .ToView("CustomerPreferredGenre");

        builder.Property(e => e.Genre)
            .HasMaxLength(100)
            .HasColumnName("genre");
        builder.Property(e => e.Pnr)
            .HasMaxLength(4000)
            .HasColumnName("PNR");
    }
}
