using GameApplication.Models;
using GameApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public class GameDevelopersRepository : IGameDevelopersRepository
    {
        private readonly DataContext _context;

        public GameDevelopersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<GameDeveloper> GetByIdAsync(int id)
        {
            return await _context.Set<GameDeveloper>().FindAsync(id);
        }

        public async Task<IEnumerable<GameDeveloper>> GetAllAsync()
        {
            return await _context.Set<GameDeveloper>().ToListAsync();
        }

        public async Task AddAsync(GameDeveloper gamedeveloper)
        {
            await _context.Set<GameDeveloper>().AddAsync(gamedeveloper);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameDeveloper gamedeveloper)
        {
            _context.Set<GameDeveloper>().Update(gamedeveloper);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gamedeveloper = await _context.Set<GameDeveloper>().FindAsync(id);
            if (gamedeveloper != null)
            {
                _context.Set<GameDeveloper>().Remove(gamedeveloper);
                await _context.SaveChangesAsync();
            }
        }
    }
}
