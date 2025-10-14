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

        [HttpGet("{id}")]
        public IActionResult GetScripture(int id)
        {
            var scripture = _context.Scriptures.Find(id);
            if (scripture == null)
            {
                return NotFound();
            }
            return Ok(scripture);
        }
        [HttpPost]
        public IActionResult CreateScripture([FromBody] ScriptureDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Scripture payload is missing.");
            }

            var scripture = new Scripture
            {
                Passage = dto.Passage,
                Description = dto.Description
            };

            _context.Scriptures.Add(scripture);
            _context.SaveChanges(); // Now scripture.Id is available

            var links = dto.LinkedStruggleIds.Select(id => new StruggleScripture
            {
                ScriptureId = scripture.Id,
                StruggleId = id,
                DateLinked = DateTime.UtcNow
            }).ToList();

            _context.StruggleScriptures.AddRange(links);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetScripture), new { id = scripture.Id }, scripture);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateScripture(int id, [FromBody] Scripture scripture)
        {
            if (id != scripture.Id)
            {
                return BadRequest("Scripture ID mismatch."); //if the id in the url does not match the id in the body of the request, return a bad request.
            }
            
            var upScripture = _context.Scriptures.Find(id);
            if (scripture == null)
            {
                return NotFound();
            }

            upScripture.Passage = scripture.Passage;
            upScripture.Description = scripture.Description;

            _context.Scriptures.Update(upScripture);
            _context.SaveChanges();
            return NoContent(); //

        }

        [HttpDelete]
        public IActionResult DeleteScripture(int id)
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