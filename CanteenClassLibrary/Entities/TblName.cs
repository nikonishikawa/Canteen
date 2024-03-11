using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblName
{
    public long NameId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public virtual ICollection<TblAdmin> TblAdmins { get; set; } = new List<TblAdmin>();

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblVendor> TblVendors { get; set; } = new List<TblVendor>();
}
