using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class ScriptureStruggleDto
    {
        public int StruggleId { get; set; }
        public int ScriptureId { get; set; }
        public DateTime DateLinked { get; set; } = DateTime.UtcNow;
    }
}