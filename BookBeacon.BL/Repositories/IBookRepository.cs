using System.Collections;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<PagedList<Book>> GetAllAsync(
        BookResourceParameters resourceParameters);
    Task<Book?> GetByIdAsync(int? id);
    Task<bool> IsIsbnUnique(string title);
    Task<bool> BookExistsAsync(int? id);
    Task <IEnumerable<Language?>?> GetLanguagesForBookAsync(int bookId);
}
