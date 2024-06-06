using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class BookConditionRepository : BaseRepository<BookCondition>, IBookConditionRepository
{
    public BookConditionRepository(BookBeaconContext context) : base(context)
    {
    }

    public async Task<bool> ConditionExistsAsync(int? conditionId)
    {
        if (conditionId == null)
            return false;

        return await DbContext.BookConditions
            .AnyAsync(c => c.Id == conditionId);
    }
}
