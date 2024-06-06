using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.Repositories;
using BookBeacon.BL.Services.CurrentUserService;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.ReservationManagerFacade;

public interface IReservationManagerFacade
{
    IUnitOfWork UnitOfWork { get; }
    IReservationRepository ReservationRepository { get; }
    IValidator<CreateReservationDto> ReservationValidator { get; }
    ICurrentUserService CurrentUserService { get; }
    ICopyRepository CopyRepository { get; }
}
