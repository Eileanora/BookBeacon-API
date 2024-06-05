using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface ICopyRepository : IBaseRepository<Copy>
{
    Task <Copy?> FindCopyByBookIdAsync(int bookId);
    Task<bool> IsCopyAvailableAsync(int bookId);
}
