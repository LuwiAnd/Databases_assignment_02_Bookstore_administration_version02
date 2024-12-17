using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class Store
{
    public int StoreId { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public string? District { get; set; }

    public int? PostalCode { get; set; }

    public string? Street { get; set; }

    public int? StreetNumber { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
    
}
