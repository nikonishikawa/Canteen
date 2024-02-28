using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblOrderStatus
{
    public long OrderId { get; set; }

    public long CusId { get; set; }

    public byte[] OrderStamp { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual TblCustomer Cus { get; set; } = null!;

    public virtual ICollection<TblOrderItem> TblOrderItems { get; set; } = new List<TblOrderItem>();

    public virtual ICollection<TblParcelInfo> TblParcelInfos { get; set; } = new List<TblParcelInfo>();
}
