using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class Book
{
    public string Isbn13 { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string? Language { get; set; }

    public decimal CurrentPrice { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
