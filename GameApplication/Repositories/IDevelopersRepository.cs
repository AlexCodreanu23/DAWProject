using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IDevelopersRepository
    {
        Task<Developers> GetByIdAsync(int id);
        Task<IEnumerable<Developers>> GetAllAsync();
        Task AddAsync(Developers developer);
        Task UpdateAsync(Developers developer);
        Task DeleteAsync(int id);
    }
}