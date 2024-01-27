using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IGameDevelopersRepository
    {
        Task<GameDeveloper> GetByIdAsync(int id);
        Task<IEnumerable<GameDeveloper>> GetAllAsync();
        Task AddAsync(GameDeveloper gamedeveloper);
        Task UpdateAsync(GameDeveloper gamedeveloper);
        Task DeleteAsync(int id);
    }
}