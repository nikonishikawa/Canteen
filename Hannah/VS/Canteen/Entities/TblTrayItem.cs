using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblTrayItem
{
    public long TrayItemId { get; set; }

    public long TrayId { get; set; }

    public long Item { get; set; }

    public decimal Quantity { get; set; }

    public DateTime AddStamp { get; set; }

    public virtual TblTray Tray { get; set; } = null!;
}
