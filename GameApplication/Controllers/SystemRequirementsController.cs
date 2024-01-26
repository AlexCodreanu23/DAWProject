using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApplication.Data;
using GameApplication.Models;

namespace GameApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemRequirementsController : ControllerBase
    {
        private readonly DataContext _context;

        public SystemRequirementsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SystemRequirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemRequirements>>> GetSystemRequirements()
        {
            return await _context.SystemRequirements.Include(s => s.Game).ToListAsync();
        }

        // GET: api/SystemRequirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRequirements>> GetSystemRequirement(int id)
        {
            var systemRequirements = await _context.SystemRequirements
                .Include(s => s.Game)
                .FirstOrDefaultAsync(m => m.RequirementsId == id);

            if (systemRequirements == null)
            {
                return NotFound();
            }

            return systemRequirements;
        }

        // POST: api/SystemRequirements
        [HttpPost]
        public async Task<ActionResult<SystemRequirements>> PostSystemRequirement(SystemRequirements systemRequirements)
        {
            _context.SystemRequirements.Add(systemRequirements);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSystemRequirement), new { id = systemRequirements.RequirementsId }, systemRequirements);
        }

        // PUT: api/SystemRequirements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemRequirement(int id, SystemRequirements systemRequirements)
        {
            if (id != systemRequirements.RequirementsId)
            {
                return BadRequest();
            }

            _context.Entry(systemRequirements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemRequirementsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/SystemRequirements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemRequirement(int id)
        {
            var systemRequirements = await _context.SystemRequirements.FindAsync(id);
            if (systemRequirements == null)
            {
                return NotFound();
            }

            _context.SystemRequirements.Remove(systemRequirements);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemRequirementsExists(int id)
        {
            return _context.SystemRequirements.Any(e => e.RequirementsId == id);
        }
    }
}
