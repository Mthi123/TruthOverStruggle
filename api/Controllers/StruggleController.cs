using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Dtos;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Struggle")]
    public class StruggleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StruggleController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetStrugglesNames() //just the names that appear in the list
        {
            var struggleNames = _context.Struggles
            .Select(s => new StruggleDto {Id = s.Id, Name = s.Name}) // s is the new instance of the object 'StrugglesDto.
            .ToList();                                               // we're loading blueprint attrbs "Id" and "Name" into s
                                                                     // so, we select those two attrbs and listing them tgth.
            return Ok(struggleNames); //id + name = strugglenames aweh.
        }

        [HttpGet("{id}")]
        public IActionResult GetStruggle(int id) //specifes struggle deets.
        {
            var struggle = _context.Struggles.Find(id);
            if (struggle == null)
            {
                return NotFound();
            }
            return Ok(struggle);
        }

        [HttpGet("{id}/journal")]
        public IActionResult GetJournalEntryByStruggle(int id)
        {
            var journals = _context.JournalEntryStruggles
            .Where(jes => jes.StruggleId == id) //this is sql in C#. practice this.
            .Select(jes => jes.JournalEntry)
            .ToList();

            if (journals.Any()) //whot is this
            {
                return NotFound();
            }
            return Ok(journals);
        }

        [HttpGet("{id}/scripture")]
        public IActionResult GetScriptureByStruggle(int id) //uses ScriptureStruggle
        {
            var scriptures = _context.StruggleScriptures
            .Where(sts => sts.StruggleId == id)
            .Select(sts => sts.Scripture)
            .ToList();

            if (scriptures.Any())
            {
                return NotFound();
            }
            return Ok(scriptures);
        }

        [HttpPost]
        public IActionResult CreateStruggle([FromBody] StruggleDto dto) //[FromBody] is used to tell the controller that the data will be coming from the body of the request.
        {
            if (dto == null)
            {
                return BadRequest("Struggle is null.");
            }

            var struggle = new Struggle
            {
                Name = dto.Name,
                Description = dto.Description,
                Root = dto.Root

            };
            _context.Struggles.Add(struggle);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStruggle), new { id = struggle.Id }, struggle);

        }

        [HttpPost("{id}")]
        public IActionResult AddStruggleToEntry(int struggleId, [FromBody] int journalEntryId)
        {
            var journalEntry = _context.JournalEntries.Find(journalEntryId); //fetching these two from method body
            var struggle = _context.Struggles.Find(struggleId);

            if (struggle == null || journalEntry == null)
            {
                return NotFound();
            }
            var link = new JournalEntryStruggle
            {
                StruggleId = struggle.Id,
                JournalEntryId = journalEntry.Id,
                DateLinked = DateTime.UtcNow
            };

            _context.JournalEntryStruggles.Add(link);
            _context.SaveChanges();
            return Ok(link);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStruggle(int id, [FromBody] Struggle struggle)
        {
            if (id != struggle.Id)
            {
                return BadRequest("Struggle ID Mismatch");
            }

            var upStruggle = _context.Struggles.Find(id);
            if (upStruggle == null)
            {
                return NotFound();
            }

            upStruggle.Name = struggle.Name;
            upStruggle.Root = struggle.Root;
            upStruggle.Description = struggle.Description;

            _context.Struggles.Update(upStruggle);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        public IActionResult DeleteStruggle(int id)
        {
            var struggle = _context.Struggles.Find(id);
            if (struggle == null)
            {
                return NotFound();
            }

            _context.Struggles.Remove(struggle);
            _context.SaveChanges();
            return NoContent();
        }
    }
}