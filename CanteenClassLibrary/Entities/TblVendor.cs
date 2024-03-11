using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblVendor
{
    public long VendorId { get; set; }

    public long VendCredentials { get; set; }

    public long VendName { get; set; }

    public long VendAddress { get; set; }

    public long Position { get; set; }

    public long Status { get; set; }

    public virtual TblPosition PositionNavigation { get; set; } = null!;

    public virtual TblArchive StatusNavigation { get; set; } = null!;

    public virtual ICollection<TblArchive> TblArchives { get; set; } = new List<TblArchive>();

    public virtual TblAddressGeneral VendAddressNavigation { get; set; } = null!;

    public virtual TblCredential VendCredentialsNavigation { get; set; } = null!;

    public virtual TblName VendNameNavigation { get; set; } = null!;
}
