using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblOrderCancelled
{
    public long OrderCancelledId { get; set; }

    public long OrderId { get; set; }

    public long CancelledBy { get; set; }

    public DateTime CancelledStamp { get; set; }

    public string Reason { get; set; } = null!;

    public long Status { get; set; }

    public virtual TblOrderStatus Order { get; set; } = null!;
}
