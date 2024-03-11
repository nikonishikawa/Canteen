using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblAdmin
{
    public long AdminId { get; set; }

    public long AdminCredentials { get; set; }

    public long AdminName { get; set; }

    public long Status { get; set; }

    public virtual TblCredential AdminCredentialsNavigation { get; set; } = null!;

    public virtual TblName AdminNameNavigation { get; set; } = null!;

    public virtual TblArchive StatusNavigation { get; set; } = null!;

    public virtual ICollection<TblArchive> TblArchives { get; set; } = new List<TblArchive>();
}
