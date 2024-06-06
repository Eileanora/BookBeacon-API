using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<PagedList<Author>> GetAllAsync(AuthorResourceParameters resourceParameters);
    Task<bool> IsNameUnique(string firstName, string lastName);
    public Task<Author?> GetByIdAsync(int id);
    public Task<Author?> GetByNameAsync(string firstName, string lastName);
    Task<bool> AuthorExistsAsync(int? id);
}
