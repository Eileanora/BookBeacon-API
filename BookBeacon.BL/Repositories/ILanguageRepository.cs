using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface ILanguageRepository : IBaseRepository<Language>
{
    Task<List<Language>> GetLanguageByIdsAsync(List<int> ids);
}

