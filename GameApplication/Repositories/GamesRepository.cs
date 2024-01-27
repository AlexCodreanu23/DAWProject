using GameApplication.Models;
using GameApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly DataContext _context; 

        public GamesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Set<Game>().FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Set<Game>().ToListAsync();
        }

        public async Task AddAsync(Game game)
        {
            await _context.Set<Game>().AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Set<Game>().Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.Set<Game>().FindAsync(id);
            if (game != null)
            {
                _context.Set<Game>().Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}
