using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> CategoryExistsAsync(int? id);
}