using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class CombinedAddressGeneralDto
    {
        public long GenAddressId { get; set; }

        public long AddressId { get; set; }

        public string Email { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        //AddressDto

        public string Barangay { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }
    }
}
