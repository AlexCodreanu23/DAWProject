using GameApplication.Data;
using GameApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GameApplication.Controllers.GamesController;

namespace GameApplication.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> UpdateGameAsync(int id, Game game)
        {
            if (id != game.GameId)
            {
                return false;
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return false;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<string>> GetGamesWithMoreThanFourReviewsAsync()
        {
            return await _context.Games
                .Where(g => g.Reviews.Count > 4)
                .Select(g => g.Title)
                .ToListAsync();
        }

        public async Task<List<Game>> GetGamesWithSystemRequirementsAsync()
        {
            return await _context.Games
                .Include(g => g.SystemRequirements)
                .ToListAsync();
        }

        public async Task<List<DeveloperGameCount>> GetDeveloperGameCountsAsync()
        {
            return await _context.GameDevelopers
                .Join(_context.Developers,
                      gameDeveloper => gameDeveloper.DeveloperId,
                      developer => developer.DeveloperId,
                      (gameDeveloper, developer) => new { gameDeveloper, developer })
                .GroupBy(joinResult => joinResult.developer)
                .Select(group => new DeveloperGameCount
                {
                    DeveloperName = group.Key.Name,
                    GameCount = group.Count()
                })
                .ToListAsync();
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
