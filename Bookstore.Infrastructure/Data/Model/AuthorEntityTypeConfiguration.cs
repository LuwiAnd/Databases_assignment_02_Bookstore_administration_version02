using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__authors__3213E83F6A6E8513");

        builder.ToTable("authors");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.BirthDate).HasColumnName("birthDate");
        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .HasColumnName("firstName");
        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .HasColumnName("lastName");

        builder.HasMany(d => d.BookIsbns).WithMany(p => p.Authors)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorsBooksJunction",
                r => r.HasOne<Book>().WithMany()
                    .HasForeignKey("BookIsbn")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__authorsBo__bookI__4F1DA8B1"),
                l => l.HasOne<Author>().WithMany()
                    .HasForeignKey("AuthorId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__authorsBo__autho__4E298478"),
                j =>
                {
                    j.HasKey("AuthorId", "BookIsbn").HasName("PK__authorsB__73FD9F4B5892CA23");
                    j.ToTable("authorsBooksJunction");
                    j.IndexerProperty<int>("AuthorId").HasColumnName("authorID");
                    j.IndexerProperty<string>("BookIsbn")
                        .HasMaxLength(14)
                        .HasColumnName("bookISBN");
                });
    }
}
