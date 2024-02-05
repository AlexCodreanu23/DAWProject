using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> CreateReviewAsync(Review review);
        Task<bool> UpdateReviewAsync(int id, Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
