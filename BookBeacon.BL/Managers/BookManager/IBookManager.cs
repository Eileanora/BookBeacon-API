using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.ResourceParameters;

namespace BookBeacon.BL.Managers.BookManager;

public interface IBookManager
{
    Task<PagedList<BookDto>> GetAllAsync(
        BookResourceParameters resourceParameters);
    
    Task<BookDto?> GetByIdAsync(int id);
    
    Task<BookDto?> CreateAsync(BookDto bookDto);
    
    Task UpdateAsync(BookDto bookDto);
    
    Task<bool> DeleteAsync(int id);  
}
