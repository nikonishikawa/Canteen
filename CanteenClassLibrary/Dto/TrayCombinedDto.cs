using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class TrayCombinedDto
    {
        public long CusId { get; set; }
        public long Status { get; set; }

        public long TrayTempId { get; set; }
        public long Item { get; set; }
        public int Quantity { get; set; }
        public DateTime AddStamp { get; set; }
    }
}
