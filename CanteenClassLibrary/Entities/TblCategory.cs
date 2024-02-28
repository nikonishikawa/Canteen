using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblCategory
{
    public long CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TblItem> TblItems { get; set; } = new List<TblItem>();
}
