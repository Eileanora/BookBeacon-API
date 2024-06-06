using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.Managers.JwtTokenManager;
using BookBeacon.BL.Repositories;
using BookBeacon.BL.Services.CurrentUserService;
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
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;

    private readonly IJwtTokenManager _jwtTokenManager;

    public AuthService(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IValidator<UserForRegisterDto> registerValidator,
        IValidator<UserForLoginDto> loginValidator,
        IJwtTokenManager jwtTokenManager,
        ICurrentUserService currentUserService,
        IUserRepository userRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
        _jwtTokenManager = jwtTokenManager;
        _currentUserService = currentUserService;
        _userRepository = userRepository;
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

    public async Task<UserInfoDto?> GetUserInfoAsync()
    {
        var currentUser = _currentUserService.GetCurrentUser();
        
        var user = await _userRepository.GetByIdAsync(currentUser.UserId);
        if (user == null)
            return null;

        var roles = await _userManager.GetRolesAsync(user);
        var userInfo = user.ToUserInfoDto(roles);

        return userInfo;
    }
}
