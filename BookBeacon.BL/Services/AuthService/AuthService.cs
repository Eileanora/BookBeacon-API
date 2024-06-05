using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.Managers.JwtTokenManager;
using BookBeacon.Models.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BookBeacon.BL.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly IValidator<UserForRegisterDto> _registerValidator;
    private readonly IValidator<UserForLoginDto> _loginValidator;

    private readonly IJwtTokenManager _jwtTokenManager;

    public AuthService(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IValidator<UserForRegisterDto> registerValidator,
        IValidator<UserForLoginDto> loginValidator,
        IJwtTokenManager jwtTokenManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
        _jwtTokenManager = jwtTokenManager;
    }

    public async Task<IdentityResult> RegisterAsync(UserForRegisterDto userDto)
    {
        var validationResult = await _registerValidator.ValidateAsync(userDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = userDto.ToCreateEntity();

        return await _userManager.CreateAsync(user, userDto.Password);
    }

    public async Task AddToRoleAsync(string userName, string role)
    {
        var user = await _userManager.FindByNameAsync(userName);
        await _userManager.AddToRoleAsync(user, role);
    }

    public Task<User> FindByEmailAsync(string Id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto>? LoginAsync(UserForLoginDto userDto)
    {
        var validationResult = await _loginValidator.ValidateAsync(
            userDto,
            options => options.IncludeRuleSets("business"));

        if (!validationResult.IsValid)
            return null;
        
        var user = await _userManager.FindByNameAsync(userDto.UserName);
        var roles = await _userManager.GetRolesAsync(user);
        var loginUser = user.ToLoginDto(roles);
        var token = _jwtTokenManager.GenerateAccessToken(loginUser);
        loginUser.Token = token;

        return loginUser;
    }

    // public async Task<IdentityResult> AddToRoleAsync(User user, string role)
    // {
    //     return await _userManager.AddToRoleAsync(user, role);
    // }
    //
    // public async Task<User> FindByEmailAsync(string Id)
    // {
    //     return await _userManager.FindByIdAsync(Id);
    // }
    //
    // public async Task<UserDto> LoginAsync(UserDto userDto)
    // {
    //     var validationResult = await _userValidator.ValidateAsync(userDto);
    //
    //     if (!validationResult.IsValid)
    //     {
    //         throw new ValidationException(validationResult.Errors);
    //     }
    //
    //     var user = await _userManager.FindByEmailAsync(userDto.Email);
    //     var roles = await _userManager.GetRolesAsync(user);
    //     var loginUser = user.ToLoginDto();
    //     var token = _jwtTokenManager.GenerateAccessToken(loginUser);
    //     loginUser.Token = token;
    //
    //     return loginUser;
    // }
    
    // public async Task<bool> FindByIdAsync(string id)
    // {
    //     return await _userManager.FindByIdAsync(id) != null;
    // }
    //
    // public async Task<UserDto> AssignRolesAsync(int userId, string role)
    // {
    //     var user = await _userManager.FindByIdAsync(userId);
    //     await _userManager.AddToRoleAsync(user, role);
    //     
    //     
    //
    //     return userDto;
    // }
}

