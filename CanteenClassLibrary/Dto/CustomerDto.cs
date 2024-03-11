using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class CustomerDto
    {
        public long CustomerId { get; set; }

        public long CusCredentials { get; set; }

        public long CusName { get; set; }

        public long CusAddress { get; set; }

        public long Membership { get; set; }

        public long Status { get; set; }
    }
}
