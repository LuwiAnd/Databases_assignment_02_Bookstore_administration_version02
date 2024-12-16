using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class Review
{
    public string Isbn13 { get; set; } = null!;

    public DateOnly CustomerBirthDate { get; set; }

    public string CustomerPnrLastFourDigits { get; set; } = null!;

    public int Stars { get; set; }

    public string? Review1 { get; set; }

    public int? ReviewVoteHelpfulCount { get; set; }

    public int? ReviewVoteNotHelpfulCount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Book Isbn13Navigation { get; set; } = null!;
}
