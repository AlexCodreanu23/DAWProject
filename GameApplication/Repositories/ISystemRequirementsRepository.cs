using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface ISystemRequirementsRepository
    {
        Task<SystemRequirements> GetByIdAsync(int id);
        Task<IEnumerable<SystemRequirements>> GetAllAsync();
        Task AddAsync(SystemRequirements systemRequirements);
        Task UpdateAsync(SystemRequirements systemRequirements);
        Task DeleteAsync(int id);
    }
}