using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.Dtos;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/StruggleScripture")]
    [ApiController]
    
public class StruggleScriptureApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StruggleScriptureApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
        public IActionResult LinkScriptureToStruggle([FromBody] ScriptureStruggleDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid input.");

            var exists = _context.StruggleScriptures.Any(ss =>
                ss.StruggleId == dto.StruggleId && ss.ScriptureId == dto.ScriptureId);

            if (exists)
                return Conflict("This scripture is already linked to the struggle.");

            var link = new StruggleScripture
            {
                StruggleId = dto.StruggleId,
                ScriptureId = dto.ScriptureId,
                DateLinked = dto.DateLinked
            };

            _context.StruggleScriptures.Add(link);
            _context.SaveChanges();

            return Ok(link);
        }


    [HttpGet("struggle/{struggleId}")]
    public IActionResult GetScripturesForStruggle(int struggleId)
    {
        var scriptures = _context.StruggleScriptures
            .Where(ss => ss.StruggleId == struggleId)
            .Include(ss => ss.Scripture)
            .Select(ss => ss.Scripture)
            .ToList();

        return Ok(scriptures);
    }

    [HttpDelete]
        public IActionResult UnlinkScriptureFromStruggle([FromBody] ScriptureStruggleDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid input.");

            var existing = _context.StruggleScriptures.FirstOrDefault(ss =>
                ss.StruggleId == dto.StruggleId && ss.ScriptureId == dto.ScriptureId);

            if (existing == null)
                return NotFound();

            _context.StruggleScriptures.Remove(existing);
            _context.SaveChanges();

            return NoContent();
        }

    }

}