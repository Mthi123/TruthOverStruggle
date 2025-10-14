using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Struggle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Root { get; set; } = string.Empty;

        public ICollection<StruggleScripture> StruggleScriptures { get; set; } = new List<StruggleScripture>();
        public ICollection<JournalEntryStruggle> JournalEntryStruggles { get; set; } = new List<JournalEntryStruggle>();
    }
}