using GameApplication.Data;
using GameApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataContext _context;

        public ReviewService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews
                .Include(r => r.Game)
                .Include(r => r.Users)
                .ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.Game)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> UpdateReviewAsync(int id, Review review)
        {
            if (id != review.ReviewId)
            {
                return false;
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
