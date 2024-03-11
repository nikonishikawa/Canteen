using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class MembershipDto
    {
        public long MemberShipId { get; set; }

        public string Membership { get; set; }

        public short LoyaltyPoints { get; set; }

        public string Status { get; set; }
    }
}
