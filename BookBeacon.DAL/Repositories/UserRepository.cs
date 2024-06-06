using BookBeacon.BL.Repositories;
using BookBeacon.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _userManager.Users
            .Include(u => u.Gender)
            .Include(u => u.MembershipType)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
