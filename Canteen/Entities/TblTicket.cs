using System;
using System.Collections.Generic;

namespace Canteen.Entities;

public partial class TblTicket
{
    public long TicketId { get; set; }

    public string Category { get; set; } = null!;

    public long CreatedBy { get; set; }

    public DateTime CreatedStamp { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long CateredBy { get; set; }

    public long CateredStamp { get; set; }

    public long Status { get; set; }

    public string Priority { get; set; } = null!;

    public virtual TblCustomer CreatedByNavigation { get; set; } = null!;

    public virtual TblTicketStatus StatusNavigation { get; set; } = null!;
}
