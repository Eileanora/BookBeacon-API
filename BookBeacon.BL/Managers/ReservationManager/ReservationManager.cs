using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.Helpers.Facades.ReservationManagerFacade;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.BL.Managers.ReservationManager;

public class ReservationManager : IReservationManager
{
    private readonly IReservationManagerFacade _reservationManagerFacade;
    
    public ReservationManager(IReservationManagerFacade reservationManagerFacade)
    {
        _reservationManagerFacade = reservationManagerFacade;
    }
    
    public async Task<PagedList<ReservationDto>> GetAllAsync(ReservationResourceParameters resourceParameters)
    {
        var currentUser = _reservationManagerFacade.CurrentUserService
            .GetCurrentUser();
        
        var reservations = await _reservationManagerFacade.ReservationRepository
            .GetAllAsync(resourceParameters, currentUser.UserId, currentUser.IsAdmin);
        
        return reservations.ToListDto();
    }

    public async Task<ReservationDto?>? GetByIdAsync(int id)
    {
        var currentUser = _reservationManagerFacade.CurrentUserService
            .GetCurrentUser();
        
        var reservation = await _reservationManagerFacade.ReservationRepository
            .GetByIdAsync(id, currentUser.UserId, currentUser.IsAdmin);

        return reservation?.ToDto();
    }

    public async Task<ReservationDto?> CreateAsync(CreateReservationDto reservationDto)
    {
        var currentUser = _reservationManagerFacade.CurrentUserService
            .GetCurrentUser();
        
        reservationDto.UserId = currentUser.UserId;

        var validationResult = await _reservationManagerFacade.ReservationValidator
            .ValidateAsync(
                reservationDto, options => options.IncludeRuleSets("business"));
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var copy = await _reservationManagerFacade.CopyRepository
            .FindCopyByBookIdAsync(reservationDto.BookId);

        var reservation = reservationDto.ToEntity();
        reservation.CopyId = copy.Id;
        
        var createdReservation = await _reservationManagerFacade.ReservationRepository
            .CreateAsync(reservation);
        
        return createdReservation?.ToDto();
    }

    public async Task CancelAsync(int id)
    {
        var reservation = await _reservationManagerFacade.ReservationRepository
            .GetByIdAsync(id);
        reservation.IsReturned = true;
        _reservationManagerFacade.ReservationRepository
            .Update(reservation);
        
        await _reservationManagerFacade.UnitOfWork.SaveAsync();
    }

    public Task UpdateAsync(int id, ReservationDto reservationDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reservation = await _reservationManagerFacade.ReservationRepository
            .GetByIdAsync(id);
        
        if (reservation == null)
            return false;
        
        _reservationManagerFacade.ReservationRepository
            .Delete(reservation);
        
        await _reservationManagerFacade.UnitOfWork.SaveAsync();
        return true;
    }
}
