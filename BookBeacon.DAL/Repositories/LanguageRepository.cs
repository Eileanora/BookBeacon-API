using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class LanguageRepository : BaseRepository<Language>, ILanguageRepository
{
    public LanguageRepository(BookBeaconContext context) : base(context)
    {
    }
        
    public async Task<List<Language>> GetLanguageByIdsAsync(List<int> ids)
    {
        return await DbContext.Languages
            .Where(g => ids.Contains(g.Id))
            .ToListAsync();
    }
}