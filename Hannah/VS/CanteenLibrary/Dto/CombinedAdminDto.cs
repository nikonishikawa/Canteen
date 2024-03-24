using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class CombinedAdminDto
    {
        public long AdminId { get; set; }

        //CredentialsDto
        public long CredentialsId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //NameDto
        public long NameId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public long Status { get; set; }
    }
}
