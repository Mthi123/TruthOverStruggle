using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class ScriptureDto
    {
        public int Id { get; set; }
        public string Passage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int>? LinkedStruggleIds { get; set; } = new();

    }
}