using System.Linq.Dynamic.Core;
using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.DAL.Context;
using BookBeacon.DAL.Helpers.SortHelper;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class CopyRepository : BaseRepository<Copy>, ICopyRepository
{
    private readonly ISortHelper<Copy> _sortHelper;
    public CopyRepository(
        ISortHelper<Copy> sortHelper,
        BookBeaconContext context) : base(context)
    {
        _sortHelper = sortHelper;
    }
    
    public async Task<bool> IsCopyAvailableAsync(int bookId)
    {
        var ans = await DbContext.Copies
            .AsNoTracking()
            .AnyAsync(c => c.BookId == bookId 
                           && c.IsAvailable);
        return ans;
    }

    public async Task<Copy?> GetByIdAsync(int copyId)
    {
        return await DbContext.Copies
            .AsNoTracking()
            .Include(c => c.Book)
            .Include(c => c.Condition)
            .Include(c => c.Language)
            .FirstOrDefaultAsync(c => c.Id == copyId);
    }

    public async Task<PagedList<Copy>> GetAllAsync(CopyResourceParameters resourceParameters)
    {
        var collection = DbContext.Copies as IQueryable<Copy>;

        collection = collection
            .AsNoTracking()
            .Include(c => c.Book)
            .Include(c => c.Condition)
            .Include(c => c.Language);
        
        collection = collection
            .Where(c => c.BookId == resourceParameters.BookId);
        
        collection = ApplyFiltering(collection, resourceParameters);
        var sortedList = _sortHelper.ApplySort(collection, resourceParameters.OrderBy);

        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }

    public async Task<Copy?> FindCopyByBookIdAsync(int bookId)
    {
        return await DbContext.Copies
            .AsNoTracking()
            .Include(c => c.Book)
            .Include(c => c.Condition)
            .FirstOrDefaultAsync(c => c.BookId == bookId 
                                      && c.IsAvailable);
    }
    
    private IQueryable<Copy> ApplyFiltering(
        IQueryable<Copy> collection, CopyResourceParameters resourceParameters)
    {
        if (!string.IsNullOrWhiteSpace(resourceParameters.IsAvailable))
        {
            var isAvailable = resourceParameters.IsAvailable.Trim();
            collection = collection.Where(c =>
                c.IsAvailable.ToString().Contains(isAvailable, StringComparison.CurrentCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(resourceParameters.Condition))
        {
            var condition = resourceParameters.Condition.Trim();
            collection = collection.Where(c =>
                c.Condition.Name.Contains(condition, StringComparison.CurrentCultureIgnoreCase));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.Language))
        {
            var language = resourceParameters.Language.Trim();
            collection = collection.Where(c =>
                c.Language.Name.Contains(language, StringComparison.CurrentCultureIgnoreCase));
        }

        return collection;
    }
}
