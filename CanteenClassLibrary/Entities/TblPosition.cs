using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblPosition
{
    public long PositionId { get; set; }

    public string Position { get; set; } = null!;

    public virtual ICollection<TblVendor> TblVendors { get; set; } = new List<TblVendor>();
}
