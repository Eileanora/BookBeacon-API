using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Helpers.Facades.BookManagerFacade;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.BL.Managers.BookManager;

public class BookManager : IBookManager
{
    private readonly IBookManagerFacade _bookManagerFacade;
    public BookManager(IBookManagerFacade bookManagerFacade)
    {
        _bookManagerFacade = bookManagerFacade;
    }
    public async Task<PagedList<BookDto>> GetAllAsync(
        BookResourceParameters resourceParameters)
    {
        var books = await _bookManagerFacade.BookRepository
            .GetAllAsync(resourceParameters);
        
        return books.ToListDto();
    }

    public async Task<BookDto?> GetByIdAsync(int id)
    {
        var book = await _bookManagerFacade.BookRepository
            .GetByIdAsync(id);
        
        var languages = await _bookManagerFacade.BookRepository
            .GetLanguagesForBookAsync(id);
        
        return book?.ToDto(languages);
    }

    public async Task<BookDto?> CreateAsync(BookDto bookDto)
    {
        var validationResult = await _bookManagerFacade.BookValidator.ValidateAsync(
            bookDto,
            options => options.IncludeRuleSets("CreateBusiness"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Fetch existing genres and languages
        var existingGenres = await _bookManagerFacade.GenreRepository
            .GetGenresByIdsAsync(bookDto.GenreIds.ToList());

        var bookToCreate = bookDto.ToCreateEntity(existingGenres);

        var createdBook = await _bookManagerFacade.BookRepository
            .CreateAsync(bookToCreate);

        await _bookManagerFacade.UnitOfWork.SaveAsync();
        return createdBook.ToCreatedDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _bookManagerFacade.BookRepository
            .GetByIdAsync(id);
        if (book == null)
            return false;
        _bookManagerFacade.BookRepository.Delete(book);
        await _bookManagerFacade.UnitOfWork.SaveAsync();
        return true;
    }
    
    public async Task UpdateAsync(BookDto bookDto)
    {
        var validationResult = await _bookManagerFacade.BookValidator.ValidateAsync(
            bookDto,
            options => options.IncludeRuleSets("UpdateBusiness"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var book = await _bookManagerFacade.BookRepository
            .GetByIdAsync(bookDto.Id);
        if (book == null)
            throw new ValidationException("Book not found");

        book = bookDto.ToUpdateEntity(book);

        _bookManagerFacade.BookRepository.Update(book);
        await _bookManagerFacade.UnitOfWork.SaveAsync();
    }
}
