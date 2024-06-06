using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.BookManagerFacade;

public interface IBookManagerFacade
{
    IUnitOfWork UnitOfWork { get; }
    IBookRepository BookRepository { get; }
    IValidator<BookDto> BookValidator { get; }
    ILanguageRepository LanguageRepository { get; }
    IGenreRepository GenreRepository { get; }
}
