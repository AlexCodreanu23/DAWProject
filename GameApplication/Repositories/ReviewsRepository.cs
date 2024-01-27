using GameApplication.Models;
using GameApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly DataContext _context;

        public ReviewsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Reviews> GetByIdAsync(int id)
        {
            return await _context.Set<Reviews>().FindAsync(id);
        }

        public async Task<IEnumerable<Reviews>> GetAllAsync()
        {
            return await _context.Set<Reviews>().ToListAsync();
        }

        public async Task AddAsync(Reviews reviews)
        {
            await _context.Set<Reviews>().AddAsync(reviews);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reviews reviews)
        {
            _context.Set<Reviews>().Update(reviews);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reviews = await _context.Set<Reviews>().FindAsync(id);
            if (reviews != null)
            {
                _context.Set<Reviews>().Remove(reviews);
                await _context.SaveChangesAsync();
            }
        }
    }
}
