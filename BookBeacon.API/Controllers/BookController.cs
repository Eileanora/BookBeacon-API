using Asp.Versioning;
using BookBeacon.API.Helpers.Facades.BookControllerFacade;
using BookBeacon.API.Helpers.InputValidator;
using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<IActionResult> GetAllBooksAsync(
        [FromQuery] BookResourceParameters resourceParameters)
    {
        var books = await _bookControllerFacade
            .BookManager.GetAllAsync(resourceParameters);
        
        _bookControllerFacade.PaginationHelper
            .CreateMetaDataHeader(
                books, resourceParameters, Response.Headers, Url, "GetAllBooks");
    
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
    
    
    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBookAsync(
        [FromBody] BookDto book)
    {
        var validationResult = await _bookControllerFacade.BookValidator.ValidateAsync(
            book,
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        var newBook = await _bookControllerFacade.BookManager.CreateAsync(book);
        return CreatedAtRoute("GetBook",
            new { bookId = newBook.Id },
            newBook);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
        var deleted = await _bookControllerFacade.BookManager.DeleteAsync(bookId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
    
    [HttpPatch("{bookId}")]
    public async Task<IActionResult> UpdateBook(
        int bookId,
        JsonPatchDocument<BookDto> patchDocument)
    {
        var book = await _bookControllerFacade.BookManager.GetByIdAsync(bookId);
        
        if (book == null)
            return NotFound();
        
        var bookToPatch = book.ToUpdateDto();
        patchDocument.ApplyTo(bookToPatch, ModelState);
        
        var validationResult = await _bookControllerFacade.BookValidator.ValidateAsync(
            bookToPatch,
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        await _bookControllerFacade.BookManager.UpdateAsync(bookToPatch);
        
        return NoContent();
    }
    
}
