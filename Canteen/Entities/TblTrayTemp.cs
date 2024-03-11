using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblTrayTemp
{
    public long TrayTempId { get; set; }

    public long CusId { get; set; }

    public long Status { get; set; }

    public virtual ICollection<TblTrayItemsTemp> TblTrayItemsTemps { get; set; } = new List<TblTrayItemsTemp>();
}
