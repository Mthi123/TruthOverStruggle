using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos;

namespace api.Controllers
{
    [Route("api/Scripture")]
    [ApiController]
    public class ScriptureController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScriptureController(ApplicationDbContext context)
        {
            this._context = context;

        }

        [HttpGet]
        public IActionResult GetAllScriptures()
        {
            var scripture = _context.Scriptures.ToList(); //gets the scriptures from the db made by db context. hence: _context
            return Ok(scripture);
        }
        
        [HttpPost("{id}")]
        public IActionResult LinkStruggleToScripture(int struggleId, [FromBody] ScriptureDto dto)
        {
            var struggle = _context.Struggles.Find(struggleId);
            var scripture = new Scripture
            {
                BookName = dto.BookName,
                Chapter = dto.Chapter,
                VerseStart = dto.VerseStart,
                VerseEnd = dto.VerseEnd,
                VerseText = dto.VerseText,
                Translation = dto.Translation
            };

            if (struggle == null || scripture == null)
            {
                return NotFound();
            }
             var link = new StruggleScripture
             {
                 StruggleId = struggle.Id,
                 ScriptureId = scripture.Id,
                 DateLinked = DateTime.UtcNow
             };
             _context.StruggleScriptures.Add(link);
             _context.SaveChanges();
             return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStrugglLinkToScripture(int id)
        {
            var scripture = _context.Scriptures.Find(id);

            if (scripture == null)
            {
                return NotFound();
            }

            _context.Scriptures.Remove(scripture);
            _context.SaveChanges();
            return NoContent();
        }
    }
}