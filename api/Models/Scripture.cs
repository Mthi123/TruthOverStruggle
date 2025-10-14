using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public string Passage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<StruggleScripture> StruggleScriptures { get; set; } = new List<StruggleScripture>();
        //public ICollection<JournalEntryScripture> JournalEntryScriptures { get; set; } = new List<JournalEntryScripture>();
    }
}