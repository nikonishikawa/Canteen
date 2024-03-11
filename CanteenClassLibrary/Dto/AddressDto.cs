using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class AddressDto
    {
        public long AddressId { get; set; }

        public string Barangay { get; set; } 

        public string Region { get; set; } 

        public string PostalCode { get; set; }
    }
}
