using GameApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApplication.Repositories
{
    public interface IReviewsRepository
    {
        Task<Reviews> GetByIdAsync(int id);
        Task<IEnumerable<Reviews>> GetAllAsync();
        Task AddAsync(Reviews review);
        Task UpdateAsync(Reviews review);
        Task DeleteAsync(int id);
    }
}