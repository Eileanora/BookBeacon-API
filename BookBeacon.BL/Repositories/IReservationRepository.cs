using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    Task<PagedList<Reservation>> GetAllAsync(
        ReservationResourceParameters resourceParameters,
        string userId,
        bool isAdmin);
    Task<Reservation?> GetByIdAsync(int id, string userId, bool isAdmin);
    Task<Reservation?> GetByIdAsync(int id);
    
    Task <bool> IsReserved(string userId, int bookId);
    Task<int> GetReservationsCountAsync(string userId);
}
