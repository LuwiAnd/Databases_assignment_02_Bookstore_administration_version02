using System;
using System.Collections.Generic;

//namespace Bookstore.Infrastructure;
namespace Bookstore.Domain;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly CustomerBirthDate { get; set; }

    public string CustomerPnrLastFourDigits { get; set; } = null!;

    public int StoreId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Store Store { get; set; } = null!;
}
