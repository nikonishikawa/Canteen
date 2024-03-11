using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class ArchiveDto
    {
        public long ArchiveId { get; set; }

        public long ArchivedBy { get; set; }

        public DateTime ArchiveStamp { get; set; }

        public long Status { get; set; }
    }
}
