using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.BL.Services.AuthService;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.UserControllerFacade;

public interface IUserControllerFacade
{
    IAuthService AuthService { get; }
    IValidator<UserForRegisterDto> RegisterValidator { get; }
    IValidator<UserForLoginDto> LoginValidator { get; }
}