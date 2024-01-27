using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}