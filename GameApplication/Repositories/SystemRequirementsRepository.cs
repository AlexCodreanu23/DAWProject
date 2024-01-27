using GameApplication.Models;
using GameApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public class SystemRequirementsRepository : ISystemRequirementsRepository
    {
        private readonly DataContext _context;

        public SystemRequirementsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<SystemRequirement> GetByIdAsync(int id)
        {
            return await _context.Set<SystemRequirement>().FindAsync(id);
        }

        public async Task<IEnumerable<SystemRequirement>> GetAllAsync()
        {
            return await _context.Set<SystemRequirement>().ToListAsync();
        }

        public async Task AddAsync(SystemRequirement systemRequirements)
        {
            await _context.Set<SystemRequirement>().AddAsync(systemRequirements);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemRequirement systemRequirements)
        {
            _context.Set<SystemRequirement>().Update(systemRequirements);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var systemRequirements = await _context.Set<SystemRequirement>().FindAsync(id);
            if (systemRequirements != null)
            {
                _context.Set<SystemRequirement>().Remove(systemRequirements);
                await _context.SaveChangesAsync();
            }
        }
    }
}
