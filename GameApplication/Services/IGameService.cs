using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static GameApplication.Controllers.GamesController;

namespace GameApplication.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> CreateGameAsync(Game game);
        Task<bool> UpdateGameAsync(int id, Game game);
        Task<bool> DeleteGameAsync(int id);
        Task<List<string>> GetGamesWithMoreThanFourReviewsAsync();
        Task<List<Game>> GetGamesWithSystemRequirementsAsync();
        Task<List<DeveloperGameCount>> GetDeveloperGameCountsAsync();
    }
}
