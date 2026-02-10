using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class JournalEntryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public String? AuthorName { get; set; } 
        public DateTime Date { get; set; }
        public string Mood { get; set; } = string.Empty;
        //public string Struggle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<int>? StruggleIds { get; set; } = new();
    }
}