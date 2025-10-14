using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class StruggleScripture
    {
        public StruggleScripture() {}
        public int StruggleId { get; set; }
        [Required]
        public Struggle Struggle { get; set; }
        
        public int ScriptureId { get; set; }
        [Required]
        public Scripture Scripture { get; set; }
        public DateTime DateLinked { get; set; } = DateTime.UtcNow;
    }
}