using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class StockBalance
{
    public int StoreId { get; set; }

    public string Isbn13 { get; set; } = null!;

    public int? Count { get; set; }

    public virtual Book Isbn13Navigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
