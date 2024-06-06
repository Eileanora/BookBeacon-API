using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators.CopyValidators;

public class CopyDtoValidator : AbstractValidator<CopyDto>
{
    public CopyDtoValidator(
        IBookRepository bookRepository,
        IBookConditionRepository bookConditionRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(c => c.BookId)
                .NotEmpty()
                .WithMessage("Book ID is required.");
           
            RuleFor(c => c.ConditionId)
                .NotEmpty()
                .WithMessage("Condition ID is required.");
            
            RuleFor(c => c.IsAvailable)
                .NotEmpty()
                .WithMessage("IsAvailable is required.");
            
        });

        RuleSet("CreateBusiness", () =>
        {
            RuleFor(c => c.BookId)
                .MustAsync(async (bookId, _) => await bookRepository.BookExistsAsync(bookId))
                .WithMessage("Book is not available.");

            RuleFor(c => c.ConditionId)
                .MustAsync(async (conditionId, _) => await bookConditionRepository.ConditionExistsAsync(conditionId))
                .WithMessage("Condition is not available.");

        });


        RuleSet("UpdateBusiness", () =>
        {
            RuleFor(c => c.BookId)
                .MustAsync(async (bookId, _) => await bookRepository.BookExistsAsync(bookId))
                .WithMessage("Book is not available.");
            
            RuleFor(c => c.ConditionId)
                .MustAsync(async (conditionId, _) => await bookConditionRepository.ConditionExistsAsync(conditionId))
                .WithMessage("Condition is not available.");
        });
    }
}
