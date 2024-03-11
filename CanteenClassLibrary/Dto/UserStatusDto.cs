using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class UserStatusDto
    {
        public long UserStatusId { get; set; }

        public string Status { get; set; } = null!;
    }
}
