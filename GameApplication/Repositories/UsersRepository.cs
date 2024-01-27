using GameApplication.Models;
using GameApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _context.Set<Users>().FindAsync(id);
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _context.Set<Users>().ToListAsync();
        }

        public async Task AddAsync(Users user)
        {
            await _context.Set<Users>().AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Users user)
        {
            _context.Set<Users>().Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Set<Users>().FindAsync(id);
            if (user != null)
            {
                _context.Set<Users>().Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
