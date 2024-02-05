using GameApplication.Data;
using GameApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public class SystemRequirementService : ISystemRequirementService
    {
        private readonly DataContext _context;

        public SystemRequirementService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SystemRequirement>> GetAllSystemRequirementsAsync()
        {
            return await _context.SystemRequirements.Include(s => s.Game).ToListAsync();
        }

        public async Task<SystemRequirement> GetSystemRequirementByIdAsync(int id)
        {
            return await _context.SystemRequirements
                .Include(s => s.Game)
                .FirstOrDefaultAsync(m => m.RequirementsId == id);
        }

        public async Task<SystemRequirement> CreateSystemRequirementAsync(SystemRequirement systemRequirement)
        {
            _context.SystemRequirements.Add(systemRequirement);
            await _context.SaveChangesAsync();
            return systemRequirement;
        }

        public async Task<bool> UpdateSystemRequirementAsync(int id, SystemRequirement systemRequirement)
        {
            if (id != systemRequirement.RequirementsId)
            {
                return false;
            }

            _context.Entry(systemRequirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemRequirementExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteSystemRequirementAsync(int id)
        {
            var systemRequirement = await _context.SystemRequirements.FindAsync(id);
            if (systemRequirement == null)
            {
                return false;
            }

            _context.SystemRequirements.Remove(systemRequirement);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool SystemRequirementExists(int id)
        {
            return _context.SystemRequirements.Any(e => e.RequirementsId == id);
        }
    }
}
