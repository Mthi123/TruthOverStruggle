using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;

using api.Models;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/JournalEntryStruggle")]
    [ApiController]
    public class JournalEntryStruggleApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public JournalEntryStruggleApiController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult LinkStruggleToJournalEntry([FromBody] JournalEntryStruggleDto dto)
        {
            var exists = _context.JournalEntryStruggles.Any(js =>
                js.StruggleId == dto.StruggleId && js.JournalEntryId == dto.JournalEntryId);

            if (exists)
            {
                return Conflict("This struggle is already linked to the journal entry.");
            }

            var link = new JournalEntryStruggle
            {
                JournalEntryId = dto.JournalEntryId,
                StruggleId = dto.StruggleId,
                DateLinked = dto.DateLinked
            };

            _context.JournalEntryStruggles.Add(link);
            _context.SaveChanges();

            return Ok(link);
        }


        [HttpGet("struggle/{struggleId}")]
        public IActionResult GetStrugglesForJournalEntry(int struggleId)
        {
            var scriptures = _context.JournalEntryStruggles
                .Where(ss => ss.StruggleId == struggleId)
                .Include(ss => ss.JournalEntry)
                .Select(ss => ss.JournalEntry)
                .ToList();

            return Ok(scriptures);
        }

        [HttpDelete]
        public IActionResult UnlinkStruggleFromJournalEntry([FromBody] JournalEntryStruggleDto dto)
        {
            var existing = _context.JournalEntryStruggles.FirstOrDefault(js =>
                js.StruggleId == dto.StruggleId && js.JournalEntryId == dto.JournalEntryId);

            if (existing == null)
            {
                return NotFound();
            }

            _context.JournalEntryStruggles.Remove(existing);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
