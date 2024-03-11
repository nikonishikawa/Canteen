using CanteenClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class AddressGeneralDto
    {
        public long GenAddressId { get; set; }

        public long AddressId { get; set; }

        public string Email { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;
    }
}

