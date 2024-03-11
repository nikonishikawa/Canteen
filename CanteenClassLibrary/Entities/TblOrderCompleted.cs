using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblOrderCompleted
{
    public long OrderCompletedId { get; set; }

    public long OrderId { get; set; }

    public DateTime CompletedStamp { get; set; }

    public virtual TblOrderStatus Order { get; set; } = null!;
}
