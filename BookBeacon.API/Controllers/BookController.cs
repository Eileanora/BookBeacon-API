using Asp.Versioning;
using BookBeacon.API.Helpers.Facades.BookControllerFacade;
using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace BookBeacon.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/books")]
public class BookController : ControllerBase
{
    private readonly IBookControllerFacade _bookControllerFacade;
    
    public BookController(IBookControllerFacade bookControllerFacade)
    {
        _bookControllerFacade = bookControllerFacade;
    }
    
    [HttpGet(Name = "GetAllBooks")]
    [HttpHead]
    public async Task<IActionResult> GetAllGenresAsync(
        [FromQuery] BookResourceParameters resourceParameters)
    {
        var books = await _bookControllerFacade
            .BookManager.GetAllAsync(resourceParameters);
        
        var paginationHelper = new PaginationHelper<BookDto, BookResourceParameters>();
        paginationHelper.CreateMetaDataHeader(books,
            resourceParameters,
            Response.Headers,
            Url, "GetAllGenres");
    
        return Ok(books);
    }
    
    [HttpGet("{bookId}", Name = "GetBook")]
    public async Task<IActionResult> GetBookByIdAsync(int bookId)
    {
        var book = await _bookControllerFacade.BookManager.GetByIdAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }
    
}
