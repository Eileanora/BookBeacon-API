using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class CopyRepository : BaseRepository<Copy>, ICopyRepository
{
    public CopyRepository(BookBeaconContext context) : base(context)
    {
    }
    
    public async Task<bool> IsCopyAvailableAsync(int bookId)
    {
        var ans = await DbContext.Copies
            .AsNoTracking()
            .AnyAsync(c => c.BookId == bookId 
                           && c.IsAvailable);
        return ans;
    }

    public async Task<Copy?> FindCopyByBookIdAsync(int bookId)
    {
        return await DbContext.Copies
            .AsNoTracking()
            .Include(c => c.Book)
            .FirstOrDefaultAsync(c => c.BookId == bookId 
                                      && c.IsAvailable);
    }
}
