using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblTicketStatus
{
    public long TicketStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TblTicket> TblTickets { get; set; } = new List<TblTicket>();
}
