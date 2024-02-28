using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblOrderItem
{
    public long OrderItemId { get; set; }

    public long OrderId { get; set; }

    public long Item { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual TblItem ItemNavigation { get; set; } = null!;

    public virtual TblOrderStatus Order { get; set; } = null!;
}
