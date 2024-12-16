using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class CustomerPreferredGenre
{
    public string? Pnr { get; set; }

    public string Genre { get; set; } = null!;

    public double? AverageStars { get; set; }
}
