using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblVendor
{
    public long VendorId { get; set; }

    public long VendCredentials { get; set; }

    public long VendName { get; set; }

    public long VendAddress { get; set; }

    public long Position { get; set; }

    public long Status { get; set; }

    public virtual TblPosition PositionNavigation { get; set; } = null!;

    public virtual TblAddressGeneral VendAddressNavigation { get; set; } = null!;

    public virtual TblCredential VendCredentialsNavigation { get; set; } = null!;

    public virtual TblName VendNameNavigation { get; set; } = null!;
}
