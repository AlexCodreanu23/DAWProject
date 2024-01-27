using GameApplication.Models;
using GameApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public class DevelopersRepository : IDevelopersRepository
    {
        private readonly DataContext _context; 

        public DevelopersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Developer> GetByIdAsync(int id)
        {
            return await _context.Set<Developer>().FindAsync(id);
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _context.Set<Developer>().ToListAsync();
        }

        public async Task AddAsync(Developer developer)
        {
            await _context.Set<Developer>().AddAsync(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            _context.Set<Developer>().Update(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var developer = await _context.Set<Developer>().FindAsync(id);
            if (developer != null)
            {
                _context.Set<Developer>().Remove(developer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
