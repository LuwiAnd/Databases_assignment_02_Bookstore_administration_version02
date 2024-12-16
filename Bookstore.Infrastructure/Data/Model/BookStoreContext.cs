using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain;
using System.Reflection.Emit;

namespace Bookstore.Infrastructure.Data.Model;


// Funkar inte: scaffold-dbcontext -connection "Initial Catalog=BookstoreDB;Integrated Security=True;Trust Server Certificate=True;Server SPN=localhost" -provider "Microsoft.EntityFrameworkCore.SqlServer" -schemas "dbo"
// Fungerar:    scaffold-dbcontext -connection "Initial Catalog=LuwiBookStore;Integrated Security=True;Trust Server Certificate=True;Server SPN=localhost" -provider "Microsoft.EntityFrameworkCore.SqlServer" -schemas "dbo"

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerPreferredGenre> CustomerPreferredGenres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<StockBalance> StockBalances { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TitlesPerAuthor> TitlesPerAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Initial Catalog=LuwiBookStore;Integrated Security=True;Trust Server Certificate=True;Server SPN=localhost");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        new AuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<Author>());
        new BookEntityTypeConfiguration().Configure(modelBuilder.Entity<Book>());
        new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>());
        new CustomerPreferredGenreEntityTypeConfiguration().Configure(modelBuilder.Entity<CustomerPreferredGenre>());
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderDetailEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderDetail>());
        new ReviewEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());
        new StockBalanceEntityTypeConfiguration().Configure(modelBuilder.Entity<StockBalance>());
        new StoreEntityTypeConfiguration().Configure(modelBuilder.Entity<Store>());
        new TitlesPerAuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<TitlesPerAuthor>());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
