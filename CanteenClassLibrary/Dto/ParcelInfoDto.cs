using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class ParcelInfoDto
    {
        public long TrackingId { get; set; }

        public long OrderId { get; set; }

        public DateTime ShipStamp { get; set; }

        public string Location { get; set; } = null!;

        public long Courier { get; set; }

        public string? Notes { get; set; }

        public long Status { get; set; }
    }
}
