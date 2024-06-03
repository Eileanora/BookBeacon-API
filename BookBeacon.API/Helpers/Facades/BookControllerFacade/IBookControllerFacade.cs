using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Managers.BookManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.BookControllerFacade;

public interface IBookControllerFacade
{
    IBookManager BookManager { get; }
    IValidator<BookDto> BookValidator { get; }
    IPaginationHelper<BookDto, BookResourceParameters> PaginationHelper { get; }
}
