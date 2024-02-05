using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public interface IGameDeveloperService
    {
        Task<GameDeveloper> CreateGameDeveloperAsync(GameDeveloper gameDeveloper);
        Task<bool> DeleteGameDeveloperAsync(int id);
        Task<List<Game>> GetGamesByDeveloperAsync(int developerId);
        Task<List<Developer>> GetDevelopersByGameAsync(int gameId);
    }
}
