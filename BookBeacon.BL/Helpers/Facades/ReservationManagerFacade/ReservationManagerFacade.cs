using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.Repositories;
using BookBeacon.BL.Services.CurrentUserService;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.ReservationManagerFacade;

public class ReservationManagerFacade : IReservationManagerFacade
{
    public IUnitOfWork UnitOfWork { get; }
    public IReservationRepository ReservationRepository { get; }
    public IValidator<CreateReservationDto> ReservationValidator { get; }
    public ICurrentUserService CurrentUserService { get; }
    public ICopyRepository CopyRepository { get; }

    public ReservationManagerFacade(
        IUnitOfWork unitOfWork,
        IReservationRepository reservationRepository,
        IValidator<CreateReservationDto> reservationValidator,
        ICurrentUserService currentUserService,
        ICopyRepository copyRepository)
    {
        UnitOfWork = unitOfWork;
        ReservationRepository = reservationRepository;
        ReservationValidator = reservationValidator;
        CurrentUserService = currentUserService;
        CopyRepository = copyRepository;
    }
}
