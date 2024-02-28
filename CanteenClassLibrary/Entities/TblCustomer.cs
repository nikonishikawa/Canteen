﻿using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblCustomer
{
    public long CustomerId { get; set; }

    public long CusCredentials { get; set; }

    public long CusName { get; set; }

    public long CusAddress { get; set; }

    public long? Membership { get; set; }

    public virtual TblAddressGeneral CusAddressNavigation { get; set; } = null!;

    public virtual TblCredential CusCredentialsNavigation { get; set; } = null!;

    public virtual TblName CusNameNavigation { get; set; } = null!;

    public virtual TblMembership? MembershipNavigation { get; set; }

    public virtual ICollection<TblOrderStatus> TblOrderStatuses { get; set; } = new List<TblOrderStatus>();

    public virtual ICollection<TblTray> TblTrays { get; set; } = new List<TblTray>();
}
