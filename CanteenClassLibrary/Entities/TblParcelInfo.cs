using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblParcelInfo
{
    public long TrackingId { get; set; }

    public long OrderId { get; set; }

    public DateTime ShipStamp { get; set; }

    public string Location { get; set; } = null!;

    public long Courier { get; set; }

    public string? Notes { get; set; }

    public long Status { get; set; }

    public virtual TblCourier CourierNavigation { get; set; } = null!;

    public virtual TblOrderStatus Order { get; set; } = null!;

    public virtual TblShippingStatus StatusNavigation { get; set; } = null!;
}
