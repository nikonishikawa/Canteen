using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblItem
{
    public long ItemId { get; set; }

    public string Item { get; set; } = null!;

    public string? Description { get; set; }

    public string? FoodImage { get; set; }

    public int IsHalal { get; set; }

    public decimal Price { get; set; }

    public long Category { get; set; }

    public virtual TblCategory CategoryNavigation { get; set; } = null!;

    public virtual ICollection<TblOrderItem> TblOrderItems { get; set; } = new List<TblOrderItem>();

    public virtual ICollection<TblTrayItem> TblTrayItems { get; set; } = new List<TblTrayItem>();
}
