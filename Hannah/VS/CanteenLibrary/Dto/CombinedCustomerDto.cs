using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class CombinedCustomerDto
    {
        public long CustomerId { get; set; }

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

        //Membership
        public long MemberShipId { get; set; }
        public string Membership { get; set; } = null!;
        public short LoyaltyPoints { get; set; }
        public string MembershipStatus { get; set; } = null!;

        //Status
        public long Status { get; set; }
    }
}
