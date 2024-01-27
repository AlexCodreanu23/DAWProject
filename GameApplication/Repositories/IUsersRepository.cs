using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IUsersRepository
    {
        Task<Users> GetByIdAsync(int id);
        Task<IEnumerable<Users>> GetAllAsync();
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteAsync(int id);
    }
}