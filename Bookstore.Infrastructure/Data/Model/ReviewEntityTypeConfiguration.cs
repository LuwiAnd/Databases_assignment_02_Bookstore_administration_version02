using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(e => new { e.Isbn13, e.CustomerBirthDate, e.CustomerPnrLastFourDigits }).HasName("PK__reviews__F039465D7C424D26");

        builder.ToTable("reviews");

        builder.Property(e => e.Isbn13)
            .HasMaxLength(14)
            .HasColumnName("ISBN13");
        builder.Property(e => e.CustomerBirthDate).HasColumnName("customerBirthDate");
        builder.Property(e => e.CustomerPnrLastFourDigits)
            .HasMaxLength(4)
            .HasColumnName("customerPnrLastFourDigits");
        builder.Property(e => e.Review1).HasColumnName("review");
        builder.Property(e => e.ReviewVoteHelpfulCount).HasColumnName("reviewVoteHelpfulCount");
        builder.Property(e => e.ReviewVoteNotHelpfulCount).HasColumnName("reviewVoteNotHelpfulCount");
        builder.Property(e => e.Stars).HasColumnName("stars");

        builder.HasOne(d => d.Isbn13Navigation).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.Isbn13)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__reviews__ISBN13__4964CF5B");

        builder.HasOne(d => d.Customer).WithMany(p => p.Reviews)
            .HasForeignKey(d => new { d.CustomerBirthDate, d.CustomerPnrLastFourDigits })
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__reviews__4A58F394");
    }
}
