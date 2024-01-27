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

        public async Task<SystemRequirements> GetByIdAsync(int id)
        {
            return await _context.Set<SystemRequirements>().FindAsync(id);
        }

        public async Task<IEnumerable<SystemRequirements>> GetAllAsync()
        {
            return await _context.Set<SystemRequirements>().ToListAsync();
        }

        public async Task AddAsync(SystemRequirements systemRequirements)
        {
            await _context.Set<SystemRequirements>().AddAsync(systemRequirements);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemRequirements systemRequirements)
        {
            _context.Set<SystemRequirements>().Update(systemRequirements);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var systemRequirements = await _context.Set<SystemRequirements>().FindAsync(id);
            if (systemRequirements != null)
            {
                _context.Set<SystemRequirements>().Remove(systemRequirements);
                await _context.SaveChangesAsync();
            }
        }
    }
}
