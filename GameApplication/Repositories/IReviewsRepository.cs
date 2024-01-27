using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IReviewsRepository
    {
        Task<Review> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetAllAsync();
        Task AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(int id);
    }
}