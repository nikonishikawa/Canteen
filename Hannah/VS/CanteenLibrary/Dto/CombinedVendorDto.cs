using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class CombinedVendorDto
    {
        public long VendorId { get; set; }

        //CredentialsDto
        public long CredentialsId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //NameDto
        public long NameId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        //Address
        public long GenAddressId { get; set; }
        public long AddressId { get; set; }
        public string Barangay { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;

        //Position
        public long PositionId { get; set; }
        public string Position { get; set; }

        public long Status { get; set; }
    }
}
