using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblTrayItemsTemp
{
    public long TrayItemTempId { get; set; }

    public long TrayTempId { get; set; }

    public long Item { get; set; }

    public decimal Quantity { get; set; }

    public DateTime AddStamp { get; set; }

    public virtual TblTrayTemp TrayTemp { get; set; } = null!;
}
