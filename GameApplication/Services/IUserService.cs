using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
