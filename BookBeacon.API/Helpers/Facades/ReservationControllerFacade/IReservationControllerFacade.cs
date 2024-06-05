using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.Managers.ReservationManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.ReservationControllerFacade;

public interface IReservationControllerFacade
{
    IReservationManager ReservationManager { get; }
    IValidator<CreateReservationDto> ReservationValidator { get; }
    IPaginationHelper<ReservationDto, ReservationResourceParameters> PaginationHelper { get; }
}
