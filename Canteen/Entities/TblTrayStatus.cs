using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblTrayStatus
{
    public long StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TblTray> TblTrays { get; set; } = new List<TblTray>();
}
