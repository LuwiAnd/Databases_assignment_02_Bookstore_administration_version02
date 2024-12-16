using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class TitlesPerAuthor
{
    public string? FullName { get; set; }

    public int? Age { get; set; }

    public int? Titles { get; set; }

    public decimal? TotalStockValue { get; set; }
}
