using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblAddressGeneral
{
    public long GenAddressId { get; set; }

    public long AddressId { get; set; }

    public string Email { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public virtual TblAddress Address { get; set; } = null!;

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblVendor> TblVendors { get; set; } = new List<TblVendor>();
}
