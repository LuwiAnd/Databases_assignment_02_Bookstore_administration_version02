using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public string Isbn13 { get; set; } = null!;

    public int OrderQuantity { get; set; }

    public decimal Price { get; set; }

    public virtual Book Isbn13Navigation { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
