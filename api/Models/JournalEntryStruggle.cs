using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class JournalEntryStruggle
    {
        public JournalEntryStruggle() { }
        public int JournalEntryId { get; set; }
        [Required]
        public JournalEntry JournalEntry { get; set; }
        public int StruggleId { get; set; }
        [Required]
        public Struggle Struggle { get; set; }
        public DateTime DateLinked { get; set; } = DateTime.UtcNow;
    }
}