using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class ScriptureDto
    {
        public string BookName { get; set; }
        public int Chapter { get; set; }
        public int VerseStart { get; set; }
        public int? VerseEnd { get; set; }
        public string VerseText { get; set; }
        public string Translation { get; set; }
        public List<int>? LinkedStruggleIds { get; set; } = new();

    }
}