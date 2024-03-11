using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblCredential
{
    public long CredentialsId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<TblAdmin> TblAdmins { get; set; } = new List<TblAdmin>();

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblVendor> TblVendors { get; set; } = new List<TblVendor>();
}
