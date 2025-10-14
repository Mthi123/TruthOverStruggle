using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class JournalEntryStruggleDto
    {
        public int JournalEntryId { get; set; }
        public int StruggleId { get; set; }
        public DateTime DateLinked { get; set; }

    }
}