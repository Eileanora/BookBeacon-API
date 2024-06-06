using BookBeacon.Models.Models;

namespace BookBeacon.BL.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string id);
}
