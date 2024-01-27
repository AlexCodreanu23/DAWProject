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

        public async Task<Developers> GetByIdAsync(int id)
        {
            return await _context.Set<Developers>().FindAsync(id);
        }

        public async Task<IEnumerable<Developers>> GetAllAsync()
        {
            return await _context.Set<Developers>().ToListAsync();
        }

        public async Task AddAsync(Developers developer)
        {
            await _context.Set<Developers>().AddAsync(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developers developer)
        {
            _context.Set<Developers>().Update(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var developer = await _context.Set<Developers>().FindAsync(id);
            if (developer != null)
            {
                _context.Set<Developers>().Remove(developer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
