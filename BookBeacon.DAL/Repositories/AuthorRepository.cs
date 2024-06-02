using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.DAL.Context;
using BookBeacon.DAL.Helpers.SortHelper;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    private readonly ISortHelper<Author> _sortHelper;
    public AuthorRepository(
        BookBeaconContext context,
        ISortHelper<Author> sortHelper) : base(context)
    {
        _sortHelper = sortHelper;
    }

    public async Task<PagedList<Author>> GetAllAsync(AuthorResourceParameters resourceParameters)
    {
        var collection = DbContext.Authors as IQueryable<Author>;
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(a =>
                a.FirstName.Contains(searchQuery) ||
                a.LastName.Contains(searchQuery));
        }

        // Add filtering logic here
        if (!string.IsNullOrWhiteSpace(resourceParameters.FirstName))
        {
            var firstName = resourceParameters.FirstName.Trim();
            collection = collection.Where(a => a.FirstName == firstName);
        }

        if (!string.IsNullOrWhiteSpace(resourceParameters.LastName))
        {
            var lastName = resourceParameters.LastName.Trim();
            collection = collection.Where(a => a.LastName == lastName);
        }

        var sortedList = _sortHelper.ApplySort(collection, resourceParameters.OrderBy);

        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
    
    public async Task<bool> IsNameUnique(string firstName, string lastName)
    {
        return await DbContext.Authors
            .AnyAsync(a => a.FirstName == firstName && a.LastName == lastName);
    }
    
    public async Task<bool> IsNameUnique(int id, string firstName, string lastName)
    {
        return await DbContext.Authors
            .Where(a => a.Id != id)
            .AnyAsync(a => a.FirstName == firstName && a.LastName == lastName);
    }
    
    public async Task<Author?> GetByIdAsync(int id)
    {
        return await DbContext.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    
    public async Task<Author?> GetByNameAsync(string firstName, string lastName)
    {
        var author = await DbContext.Authors
            .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
        return author;
    }
    
    public async Task<Author?> GetByNamesAsync(string firstName, string lastName)
    {
        var author = await DbContext.Authors
            .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
        return author;
    }
}
