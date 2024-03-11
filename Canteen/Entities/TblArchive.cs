using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblArchive
{
    public long ArchiveId { get; set; }

    public long ArchivedBy { get; set; }

    public DateTime ArchiveStamp { get; set; }

    public long Status { get; set; }

    public virtual TblAdmin ArchivedByNavigation { get; set; } = null!;

    public virtual TblUserStatus StatusNavigation { get; set; } = null!;

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();
}
