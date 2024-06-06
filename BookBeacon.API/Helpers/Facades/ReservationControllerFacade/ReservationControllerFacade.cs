using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.Managers.ReservationManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.ReservationControllerFacade;

public class ReservationControllerFacade : IReservationControllerFacade
{
    public IReservationManager ReservationManager { get; }
    public IValidator<CreateReservationDto> ReservationValidator { get; }
    public IPaginationHelper<ReservationDto, ReservationResourceParameters> PaginationHelper { get; }
    
    public ReservationControllerFacade(
        IReservationManager reservationManager,
        IValidator<CreateReservationDto> reservationValidator,
        IPaginationHelper<ReservationDto, ReservationResourceParameters> paginationHelper)
    {
        ReservationManager = reservationManager;
        ReservationValidator = reservationValidator;
        PaginationHelper = paginationHelper;
    }
}
