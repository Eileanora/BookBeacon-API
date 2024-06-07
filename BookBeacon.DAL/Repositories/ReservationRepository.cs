using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.DAL.Context;
using BookBeacon.DAL.Helpers.SortHelper;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    private readonly ISortHelper<Reservation> _sortHelper;
    public ReservationRepository(
        BookBeaconContext context,
        ISortHelper<Reservation> sortHelper) : base(context)
    {
        _sortHelper = sortHelper;
    }

    public async Task<PagedList<Reservation>> GetAllAsync(
        ReservationResourceParameters resourceParameters,
        string userId,
        bool isAdmin)
    {
        var collection = DbContext.Reservations as IQueryable<Reservation>;

        collection = collection
            .AsNoTracking()
            .Include(r => r.Copy)
            .Include(r => r.User)
            .Include(r => r.Copy.Book);

        if (!isAdmin)
            collection = collection.Where(r => r.User.Id == userId);
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.BookTitle))
        {
            var bookTitle = resourceParameters.BookTitle.Trim();
            collection = collection.Where(r => r.Copy.Book.Title.Contains(bookTitle));
        }

        if (!string.IsNullOrWhiteSpace(resourceParameters.IsDue))
        {
            var isDue = resourceParameters.IsDue.Trim();
            collection = collection.Where(r => r.EndDate < DateTime.Now);
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.StartDate))
        {
            var startDate = DateTime.Parse(resourceParameters.StartDate);
            collection = collection.Where(r => r.StartDate >= startDate);
        }

        var sortedList = _sortHelper.ApplySort(collection, resourceParameters.OrderBy);
        
        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }

    public async Task<Reservation?> GetByIdAsync(
        int id, string userId, bool isAdmin)
    {
        if(isAdmin)
            return await DbContext.Reservations
                .FirstOrDefaultAsync(r => r.Id == id);
        
        return await DbContext.Reservations
            .FirstOrDefaultAsync(r => r.Id == id && r.User.Id == userId);
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await DbContext.Reservations
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> IsReserved(string userId, int bookId)
    {
        return await DbContext.Reservations
            .Include(c => c.Copy)
            .AnyAsync(r => r.User.Id == userId && r.Copy.BookId == bookId);
    }

    public async Task<int> GetReservationsCountAsync(string userId)
    {
        return await DbContext.Reservations
            .CountAsync(r => r.User.Id == userId && r.IsReturned == false);
    }
    
    public async Task<Reservation?> CreateAsync(Reservation reservation)
    {
        var entry = await DbContext.Reservations.AddAsync(reservation);
        await DbContext.SaveChangesAsync();
        return reservation;
    }
}
