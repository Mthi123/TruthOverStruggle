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
        public string BookName { get; set; }  // e.g., "John"
        public int Chapter { get; set; }      // e.g., 3
        public int VerseStart { get; set; }   // e.g., 16
        public int? VerseEnd { get; set; }    // e.g., null (single verse) or 18 (range)
        public string VerseText { get; set; } // "For God so loved the world..."
        public string Translation { get; set; } // "NIV", "ESV", etc.
        public string? BibleApiId { get; set; } // External ID from api.bible (if needed)
        public ICollection<StruggleScripture> StruggleScriptures { get; set; } = new List<StruggleScripture>();
    }
}