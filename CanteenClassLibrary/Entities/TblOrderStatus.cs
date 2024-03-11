using System;
using System.Collections.Generic;

namespace CanteenClassLibrary.Entities;

public partial class TblOrderStatus
{
    public long OrderId { get; set; }

    public long CusId { get; set; }

    public DateTime OrderStamp { get; set; }

    public decimal Cost { get; set; }

    public long ModeOfPayment { get; set; }

    public virtual TblCustomer Cus { get; set; } = null!;

    public virtual TblModeOfPayment ModeOfPaymentNavigation { get; set; } = null!;

    public virtual ICollection<TblOrderCancelled> TblOrderCancelleds { get; set; } = new List<TblOrderCancelled>();

    public virtual ICollection<TblOrderCompleted> TblOrderCompleteds { get; set; } = new List<TblOrderCompleted>();

    public virtual ICollection<TblOrderItem> TblOrderItems { get; set; } = new List<TblOrderItem>();

    public virtual ICollection<TblParcelInfo> TblParcelInfos { get; set; } = new List<TblParcelInfo>();
}
