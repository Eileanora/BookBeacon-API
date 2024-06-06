using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.ResourceParameters;

namespace BookBeacon.BL.Managers.ReservationManager;

public interface IReservationManager
{
    Task<PagedList<ReservationDto>> GetAllAsync(
        ReservationResourceParameters resourceParameters);
    
    Task<ReservationDto?>? GetByIdAsync(int id);
    
    Task<ReservationDto?> CreateAsync(CreateReservationDto reservationDto);
    
    Task CancelAsync(int id);
    
    Task UpdateAsync(int id, ReservationDto reservationDto);
    
    Task<bool> DeleteAsync(int id);  
}
