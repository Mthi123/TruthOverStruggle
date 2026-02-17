using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.DTOs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // this is gonna house change password (put), sign up (post), log in (??)
    public class AuthApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //think through the logic omg
        /*[HttpPut("id")]
        public IActionResult ChangePassword(int id, [FromBody]AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest("User mismatch.");
            }

        } 
        */

    }
}