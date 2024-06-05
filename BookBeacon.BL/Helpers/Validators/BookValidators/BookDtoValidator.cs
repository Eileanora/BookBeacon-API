using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators.BookValidators;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator(
        IBookRepository bookRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.PublicationDate).NotEmpty();
            RuleFor(x => x.ISBN).NotEmpty();
            RuleFor(x => x.Summary).NotEmpty();
            RuleFor(x => x.PageCount).NotEmpty();
            RuleFor(x => x.PublisherId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.GenreIds).NotEmpty();
            RuleFor(x => x.LanguageIds).NotEmpty();
        });
        
        RuleSet("Business", () =>
        {
            RuleFor(c => c.ISBN)
                .MustAsync(async (ISBN, _) => !await bookRepository.IsIsbnUnique(ISBN))
                .WithMessage("Book with this ISBN already exists.");
            
        });
    }
}
