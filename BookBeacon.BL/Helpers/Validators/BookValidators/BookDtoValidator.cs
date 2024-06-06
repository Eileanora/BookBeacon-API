using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators.BookValidators;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator(
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        ICategoryRepository categoryRepository,
        IGenreRepository genreRepository,
        IPublisherRepository publisherRepository)
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
        });
        
        RuleSet("Business", () =>
        {
            RuleFor(c => c.ISBN)
                .MustAsync(async (ISBN, _) => !await bookRepository.IsIsbnUnique(ISBN))
                .WithMessage("Book with this ISBN already exists.");
            
            RuleFor(c => c.AuthorId)
                .MustAsync(async (authorId, _) => await authorRepository.AuthorExistsAsync(authorId))
                .WithMessage("Author with this ID does not exist.");

            RuleFor(c => c.CategoryId)
                .MustAsync(async (categoryId, _) => await categoryRepository.CategoryExistsAsync(categoryId))
                .WithMessage("Category with this ID does not exist.");
            
            RuleFor(c => c.PublisherId)
                .MustAsync(async (publisherId, _) => await publisherRepository.PublisherExistsAsync(publisherId))
                .WithMessage("Publisher with this ID does not exist.");
            
            RuleForEach(c => c.GenreIds)
                .MustAsync(async (genreId, _) => await genreRepository.GenreExistsAsync(genreId))
                .WithMessage("Genre with this ID does not exist.");
        });
    }
}
