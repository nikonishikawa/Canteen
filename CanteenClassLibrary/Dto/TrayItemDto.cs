using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class TrayItemDto
    {
        public long TrayItemId { get; set; }

        public long TrayId { get; set; }

        public long Item { get; set; }

        public decimal Quantity { get; set; }

        public DateTime AddStamp { get; set; }
    }
}
