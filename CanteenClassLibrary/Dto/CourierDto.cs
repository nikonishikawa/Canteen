using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class CourierDto
    {
        public long CourierId { get; set; }

        public string Courier { get; set; }

        public short Status { get; set; }
    }
}
