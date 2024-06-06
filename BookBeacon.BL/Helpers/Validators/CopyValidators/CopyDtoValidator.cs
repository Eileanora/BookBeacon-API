using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators.CopyValidators;

public class CopyDtoValidator : AbstractValidator<CopyDto>
{
    public CopyDtoValidator(
        IBookRepository bookRepository,
        IBookConditionRepository bookConditionRepository,
        ILanguageRepository languageRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(c => c.BookId)
                .NotEmpty();

            RuleFor(c => c.ConditionId)
                .NotEmpty();

            RuleFor(c => c.IsAvailable)
                .NotEmpty();

            RuleFor(c => c.LanguageId)
                .NotEmpty();
        });

        RuleSet("CreateBusiness", () =>
        {
            RuleFor(c => c.BookId)
                .MustAsync(async (bookId, _) => await bookRepository.BookExistsAsync(bookId))
                .WithMessage("Book is not available.");

            RuleFor(c => c.ConditionId)
                .MustAsync(async (conditionId, _) => await bookConditionRepository.ConditionExistsAsync(conditionId))
                .WithMessage("Condition is not available.");

            RuleFor(c => c.LanguageId)
                .MustAsync(async (languageId, _) => await languageRepository.LanguageExistsAsync(languageId))
                .WithMessage("Language is not available.");

        });


        RuleSet("UpdateBusiness", () =>
        {
            RuleFor(c => c.BookId)
                .MustAsync(async (bookId, _) => await bookRepository.BookExistsAsync(bookId))
                .WithMessage("Book is not available.");

            RuleFor(c => c.ConditionId)
                .MustAsync(async (conditionId, _) => await bookConditionRepository.ConditionExistsAsync(conditionId))
                .WithMessage("Condition is not available.");

            RuleFor(c => c.LanguageId)
                .MustAsync(async (languageId, _) => await languageRepository.LanguageExistsAsync(languageId))
                .WithMessage("Language is not available.");
        });
    }
}
