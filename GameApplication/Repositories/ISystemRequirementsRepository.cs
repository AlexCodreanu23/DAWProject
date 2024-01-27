using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface ISystemRequirementsRepository
    {
        Task<SystemRequirement> GetByIdAsync(int id);
        Task<IEnumerable<SystemRequirement>> GetAllAsync();
        Task AddAsync(SystemRequirement systemRequirements);
        Task UpdateAsync(SystemRequirement systemRequirements);
        Task DeleteAsync(int id);
    }
}