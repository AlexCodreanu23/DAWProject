using GameApplication.Data;
using GameApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public class GameDeveloperService : IGameDeveloperService
    {
        private readonly DataContext _context;

        public GameDeveloperService(DataContext context)
        {
            _context = context;
        }

        public async Task<GameDeveloper> CreateGameDeveloperAsync(GameDeveloper gameDeveloper)
        {
            _context.GameDevelopers.Add(gameDeveloper);
            await _context.SaveChangesAsync();
            return gameDeveloper;
        }

        public async Task<bool> DeleteGameDeveloperAsync(int id)
        {
            var gameDeveloper = await _context.GameDevelopers.FindAsync(id);
            if (gameDeveloper == null)
            {
                return false;
            }

            _context.GameDevelopers.Remove(gameDeveloper);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Game>> GetGamesByDeveloperAsync(int developerId)
        {
            return await _context.GameDevelopers
                .Where(gd => gd.DeveloperId == developerId)
                .Select(gd => gd.Game)
                .ToListAsync();
        }

        public async Task<List<Developer>> GetDevelopersByGameAsync(int gameId)
        {
            return await _context.GameDevelopers
                .Where(gd => gd.GameId == gameId)
                .Select(gd => gd.Developers)
                .ToListAsync();
        }
    }
}
