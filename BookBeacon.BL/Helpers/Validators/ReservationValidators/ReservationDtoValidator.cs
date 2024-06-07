using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.Repositories;
using BookBeacon.Models.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BookBeacon.BL.Helpers.Validators.ReservationValidators;

public class ReservationDtoValidator : AbstractValidator<CreateReservationDto>
{
    public ReservationDtoValidator(
        ICopyRepository copyRepository,
        IReservationRepository reservationRepository,
        UserManager<User> userManager)
    {
        RuleSet("Business", () =>
        {
            // check if there is a copy available for the specified book with the specified language
            RuleFor(x => x)
                .MustAsync(async (x, _) => await copyRepository.IsCopyAvailableAsync(x.BookId))
                .WithMessage("Copy is not available.");
            
            // check if user passed the max late return count
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, _) =>
            {
                var user = await userManager.FindByIdAsync(userId);
                return user != null && user.LateReturnCount < 4;
            }).WithMessage("User has reached the maximum late return count.");
            
            // check if user passed the max allowed reservations count
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, _) =>
                {
                    var count = await reservationRepository.GetReservationsCountAsync(userId);
                    return count < 5;
                }).WithMessage("User has reached the maximum allowed reservations count.");

            RuleFor(x => x.Duration)
                .InclusiveBetween(1, 14);
            
            // check if the user has a reservation for the same book
            RuleFor(x => x)
                .MustAsync(async (x, _) => 
                    !await reservationRepository.IsReserved(x.UserId, x.BookId))
                        .WithMessage("User has already reserved this book.");
        });
        
        RuleSet("Input", () =>
        {
            RuleFor(x => x.BookId)
                .NotEmpty()
                .WithMessage("Book is required.");
            
            // RuleFor(x => x.LanguageId)
            //     .NotEmpty()
            //     .WithMessage("Language is required.");
        });
    }
}
