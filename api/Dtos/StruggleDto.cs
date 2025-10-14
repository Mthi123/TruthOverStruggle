using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class StruggleDto
    {
         public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Root { get; set; } = string.Empty;

        public List<int>? LinkedScriptureIds { get; set; } = new List<int>();
        public List<int>? LinkedJournalEntryIds { get; set; } = new List<int>();
    }
}