using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblTray
{
    public long TrayId { get; set; }

    public long CusId { get; set; }

    public long Status { get; set; }

    public virtual TblCustomer Cus { get; set; } = null!;

    public virtual TblTrayStatus StatusNavigation { get; set; } = null!;

    public virtual ICollection<TblTrayItem> TblTrayItems { get; set; } = new List<TblTrayItem>();
}
