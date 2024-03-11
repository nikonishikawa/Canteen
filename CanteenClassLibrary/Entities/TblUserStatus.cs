using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblUserStatus
{
    public long UserStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TblArchive> TblArchives { get; set; } = new List<TblArchive>();
}
