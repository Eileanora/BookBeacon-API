using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IGenreRepository : IBaseRepository<Genre>
{
    Task<PagedList<Genre>> GetAllAsync(GenreResourceParameters resourceParameters);
    Task<bool> IsNameUnique(string name);
    public Task<Genre?> GetByIdAsync(int id);
    
    public Task<Genre?> GetByNameAsync(string name);
}
