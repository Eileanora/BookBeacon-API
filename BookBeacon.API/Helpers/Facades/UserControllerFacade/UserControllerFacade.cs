using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.BL.Services.AuthService;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.UserControllerFacade;

public class UserControllerFacade : IUserControllerFacade
{
    public IAuthService AuthService { get; }
    public IValidator<UserForRegisterDto> RegisterValidator { get; }
    public IValidator<UserForLoginDto> LoginValidator { get; }
    
    
    public UserControllerFacade(
        IAuthService authService,
        IValidator<UserForRegisterDto> registerValidator,
        IValidator<UserForLoginDto> loginValidator)
    {
        AuthService = authService;
        RegisterValidator = registerValidator;
        LoginValidator = loginValidator;
    }
}
