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

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Set<Review>().FindAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Set<Review>().ToListAsync();
        }

        public async Task AddAsync(Review reviews)
        {
            await _context.Set<Review>().AddAsync(reviews);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review reviews)
        {
            _context.Set<Review>().Update(reviews);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reviews = await _context.Set<Review>().FindAsync(id);
            if (reviews != null)
            {
                _context.Set<Review>().Remove(reviews);
                await _context.SaveChangesAsync();
            }
        }
    }
}
