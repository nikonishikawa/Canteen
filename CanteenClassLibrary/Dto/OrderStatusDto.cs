using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class OrderStatusDto
    {
        public long OrderId { get; set; }

        public long CusId { get; set; }

        public DateTime OrderStamp { get; set; }

        public decimal Cost { get; set; }

    }
}
