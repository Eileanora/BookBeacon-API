using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(BookBeaconContext context) : base(context)
    {
    }
    
    public async Task<bool> PublisherExistsAsync(int? id)
    {
        return await DbContext.Publishers
            .AnyAsync(g => g.Id == id);
    }
}
