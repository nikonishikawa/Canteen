using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblShippingStatus
{
    public long StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TblParcelInfo> TblParcelInfos { get; set; } = new List<TblParcelInfo>();
}
