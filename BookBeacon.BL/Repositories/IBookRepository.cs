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
    Task<Book?> GetByIdAsync(int id);
}
