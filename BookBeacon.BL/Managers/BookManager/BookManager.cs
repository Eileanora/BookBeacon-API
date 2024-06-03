using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.Helpers.Facades.BookManagerFacade;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;

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
        return book?.ToDto();
    }

    public Task<BookDto?> CreateAsync(BookDto bookDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, BookDto bookDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}