using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblModeOfPayment
{
    public long ModeOfPaymentId { get; set; }

    public string ModeOfPayment { get; set; } = null!;

    public virtual ICollection<TblOrderStatus> TblOrderStatuses { get; set; } = new List<TblOrderStatus>();
}
