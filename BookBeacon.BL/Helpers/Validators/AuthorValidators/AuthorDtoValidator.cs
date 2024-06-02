using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators.AuthorValidators;

public class AuthorDtoValidator : AbstractValidator<AuthorDto>
{
    public AuthorDtoValidator(
        IAuthorRepository authorRepository)
    {
        RuleSet("Input", () => {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("First Name is required and more than 2 characters.");
            
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("Last Name is required and more than 2 characters.");

            RuleFor(x => x.Biography)
                .Length(2, 500)
                .When(x => x.Biography != null)
                .WithMessage("Biography must be more than 2 and less than 500 characters.");
        });
        
        RuleSet("CreateBusiness", () => {
            RuleFor(x => x)
                .MustAsync(async (x, _, cancellationToken) =>
                {
                    var existingAuthor = await authorRepository.GetByNameAsync(x.FirstName, x.LastName);
                    return existingAuthor == null;
                })
                .WithMessage("Author with this name already exists.");
        });
        
        RuleSet("UpdateBusiness", () => {
            RuleFor(x => x)
                .MustAsync(async (x, _, context, cancellationToken) =>
                {
                    var existingAuthor = await authorRepository.GetByNameAsync(x.FirstName, x.LastName);
                    var authorId = (int)context.RootContextData["authorId"];
                    return existingAuthor == null || existingAuthor.Id == authorId;
                })
                .WithMessage("Author already exists.");
        });
    }
}