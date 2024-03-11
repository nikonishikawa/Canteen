using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblArchive
{
    public long ArchiveId { get; set; }

    public long ArchivedBy { get; set; }

    public DateTime ArchiveStamp { get; set; }

    public long Status { get; set; }

    public virtual TblVendor ArchivedBy1 { get; set; } = null!;

    public virtual TblAdmin ArchivedByNavigation { get; set; } = null!;

    public virtual TblUserStatus StatusNavigation { get; set; } = null!;

    public virtual ICollection<TblAdmin> TblAdmins { get; set; } = new List<TblAdmin>();

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblVendor> TblVendors { get; set; } = new List<TblVendor>();
}
