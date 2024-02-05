using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public interface ISystemRequirementService
    {
        Task<List<SystemRequirement>> GetAllSystemRequirementsAsync();
        Task<SystemRequirement> GetSystemRequirementByIdAsync(int id);
        Task<SystemRequirement> CreateSystemRequirementAsync(SystemRequirement systemRequirement);
        Task<bool> UpdateSystemRequirementAsync(int id, SystemRequirement systemRequirement);
        Task<bool> DeleteSystemRequirementAsync(int id);
    }
}
