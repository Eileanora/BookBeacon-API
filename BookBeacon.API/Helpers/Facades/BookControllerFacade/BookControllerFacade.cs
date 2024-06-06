using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Managers.BookManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.BookControllerFacade;

public class BookControllerFacade : IBookControllerFacade
{
    public IBookManager BookManager { get; }
    public IValidator<BookDto> BookValidator { get; }
    public IPaginationHelper<BookDto, BookResourceParameters> PaginationHelper { get; }
    
    public BookControllerFacade(
        IBookManager bookManager,
        IValidator<BookDto> bookValidator,
        IPaginationHelper<BookDto, BookResourceParameters> paginationHelper)
    {
        BookManager = bookManager;
        BookValidator = bookValidator;
        PaginationHelper = paginationHelper;
    }
}
