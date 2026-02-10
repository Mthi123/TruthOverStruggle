using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Dtos;
using api.DTOs;


namespace api.Controllers
{
    [Route("api/Journal")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public JournalController(ApplicationDbContext context) //const
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllJournals()
        {
            var journals = _context.JournalEntries.ToList();
            return Ok(journals);
        }

        [HttpGet("{id}")]
        public IActionResult GetJournalEntry(int id) //GetJournalEntryByStruggle - uses journalEntryStruggle
        {
            var journal = _context.JournalEntries.Find(id);
            if (journal == null)
            {
                return NotFound();
            }
            return Ok(journal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJournalEntry([FromBody] JournalEntryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var journalEntry = new JournalEntry //dto is api-used blueprint for entities?
            {
                Title = dto.Title,
                UserId = dto.UserId,
                Date = dto.Date,
                Mood = dto.Mood,
                Content = dto.Content,
            };

            _context.JournalEntries.Add(journalEntry);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetJournalEntry), new { id = journalEntry.Id }, journalEntry);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJournal(int id, [FromBody] JournalEntry journalEntry)
        {
            if (id != journalEntry.Id)
            {
                return BadRequest("Journal ID mismatch.");
            }

            var journal = _context.JournalEntries.Find(id);
            if (journal == null)
            {
                return NotFound();
            }
            
            journal.Title = journalEntry.Title;
            journal.Mood = journalEntry.Title;
            journal.Content = journalEntry.Content;
            journal.Date = DateTime.Now;

            _context.JournalEntries.Update(journal);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJournal(int id)
        {
            var journal = _context.JournalEntries.Find(id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.JournalEntries.Remove(journal);
            _context.SaveChanges();

            return NoContent();
        }

    }
}