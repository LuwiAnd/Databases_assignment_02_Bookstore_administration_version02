using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.Data.Model;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => new { e.BirthDate, e.PnrLastFourDigits }).HasName("PK__customer__FF34033C80749312");

        builder.ToTable("customers");

        builder.Property(e => e.PnrLastFourDigits).HasMaxLength(4);
        builder.Property(e => e.Company).HasMaxLength(100);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
    }
}
