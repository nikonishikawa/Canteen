using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblMembership
{
    public long MemberShipId { get; set; }

    public string Membership { get; set; } = null!;

    public short LoyaltyPoints { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();
}
