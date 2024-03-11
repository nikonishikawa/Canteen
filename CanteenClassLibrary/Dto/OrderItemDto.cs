using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class OrderItemDto
    {
        public long OrderItemId { get; set; }

        public long OrderId { get; set; }

        public long Item { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
