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
        public IActionResult GetStruggles()
        {
            var struggle = _context.Struggles.ToList();
            return Ok(struggle);
        }

        [HttpGet("{id}")]
        public IActionResult GetStruggle(int id)
        {
            var struggle = _context.Struggles.Find(id);
            if (struggle == null)
            {
                return NotFound();
            }
            return Ok(struggle);
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

            var links = dto.LinkedScriptureIds.Select(id => new StruggleScripture
            {
                StruggleId = struggle.Id,
                ScriptureId = id,
                DateLinked = DateTime.UtcNow
            }).ToList();

            _context.StruggleScriptures.AddRange(links);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStruggle), new { id = struggle.Id }, struggle);

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