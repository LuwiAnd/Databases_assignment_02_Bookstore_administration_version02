using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class Author
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public virtual ICollection<Book> BookIsbns { get; set; } = new List<Book>();
}
