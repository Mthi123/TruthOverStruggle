using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class JournalEntry
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Mood { get; set; } = string.Empty;
        //public string Struggle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public ICollection<JournalEntryStruggle> JournalEntryStruggles { get; set; } = new List<JournalEntryStruggle>();
    }
}