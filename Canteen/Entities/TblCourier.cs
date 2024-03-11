using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblCourier
{
    public long CourierId { get; set; }

    public string Courier { get; set; } = null!;

    public short Status { get; set; }

    public virtual ICollection<TblParcelInfo> TblParcelInfos { get; set; } = new List<TblParcelInfo>();
}
