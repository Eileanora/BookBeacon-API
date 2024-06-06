using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.Models.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BookBeacon.BL.Services.AuthService;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserForRegisterDto userDto);
    Task AddToRoleAsync(string userName, string role);
    Task<User> FindByEmailAsync(string Id);
    Task<UserDto>? LoginAsync(UserForLoginDto userDto);
    Task<UserInfoDto?> GetUserInfoAsync();
}
