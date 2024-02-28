using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblAddress
{
    public long AddressId { get; set; }

    public string Barangay { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<TblAddressGeneral> TblAddressGenerals { get; set; } = new List<TblAddressGeneral>();
}
