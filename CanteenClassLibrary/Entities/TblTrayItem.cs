using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblTrayItem
{
    public long TrayItemId { get; set; }

    public long TrayId { get; set; }

    public long Item { get; set; }

    public decimal Quantity { get; set; }

    public byte[] AddStamp { get; set; } = null!;

    public virtual TblItem ItemNavigation { get; set; } = null!;

    public virtual TblTray Tray { get; set; } = null!;
}
