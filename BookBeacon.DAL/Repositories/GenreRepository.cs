using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.DAL.Context;
using BookBeacon.DAL.Helpers.SortHelper;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    private readonly ISortHelper<Genre> _sortHelper;
    public GenreRepository(
        BookBeaconContext context,
        ISortHelper<Genre> sortHelper) : base(context)
    {
        _sortHelper = sortHelper;
    }

    public async Task<PagedList<Genre>> GetAllAsync(GenreResourceParameters resourceParameters)
    {
        var collection = DbContext.Genres as IQueryable<Genre>;
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(g => g.Name.Contains(searchQuery));
        }
        // TODO: Find a better way to handle filtering
        if (!string.IsNullOrWhiteSpace(resourceParameters.Name))
        {
            var name = resourceParameters.Name.Trim();
            collection = collection.Where(g => g.Name == name);
        }
        
        var sortedList = _sortHelper.ApplySort(collection, resourceParameters.OrderBy);
        
        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }

    public async Task<bool> IsNameUnique(string name)
    {
        return await DbContext.Genres
            .AnyAsync(g => g.Name == name);
    }

    public async Task<bool> IsNameUnique(int id, string name)
    {
        return await DbContext.Genres
            .Where(g => g.Id != id)
            .AnyAsync(g => g.Name == name);
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await DbContext.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Genre?> GetByNameAsync(string name)
    {
        var genre = await DbContext.Genres
            .FirstOrDefaultAsync(g => g.Name == name);
        return genre;
    }
    public async Task<List<Genre>> GetGenresByIdsAsync(List<int> ids)
    {
        return await DbContext.Genres.Where(g => ids.Contains(g.Id)).ToListAsync();
    }
}
