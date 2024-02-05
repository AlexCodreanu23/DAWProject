using GameApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public interface IDeveloperService
    {
        Task<List<Developer>> GetAllDevelopersAsync();
        Task<Developer> GetDeveloperByIdAsync(int id);
        Task<Developer> CreateDeveloperAsync(Developer developer);
        Task<bool> UpdateDeveloperAsync(int id, Developer developer);
        Task<bool> DeleteDeveloperAsync(int id);
    }
}
