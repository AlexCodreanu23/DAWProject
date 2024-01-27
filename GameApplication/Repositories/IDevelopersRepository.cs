using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IDevelopersRepository
    {
        Task<Developer> GetByIdAsync(int id);
        Task<IEnumerable<Developer>> GetAllAsync();
        Task AddAsync(Developer developer);
        Task UpdateAsync(Developer developer);
        Task DeleteAsync(int id);
    }
}