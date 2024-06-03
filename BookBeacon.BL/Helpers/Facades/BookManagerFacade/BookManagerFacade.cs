using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.BookManagerFacade;

public class BookManagerFacade : IBookManagerFacade
{
    public IUnitOfWork UnitOfWork { get; }
    public IBookRepository BookRepository { get; }
    public IValidator<BookDto> BookValidator { get; }

    public BookManagerFacade(
        IUnitOfWork unitOfWork,
        IBookRepository bookRepository,
        IValidator<BookDto> bookValidator)
    {
        UnitOfWork = unitOfWork;
        BookRepository = bookRepository;
        BookValidator = bookValidator;
    }
}
