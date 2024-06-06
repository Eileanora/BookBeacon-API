using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.Models.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BookBeacon.BL.Helpers.Validators.UserValidators;

public class UserForLoginValidator : AbstractValidator<UserForLoginDto>
{
    public UserForLoginValidator(
        UserManager<User> userManager)
    {
        RuleSet("input", () =>
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        });
        
        RuleSet("business", () =>
        {
            RuleFor(x => x)
                .MustAsync(async (x, _) =>
                {
                    var user = await userManager.FindByNameAsync(x.UserName);
                    return user != null && await userManager.CheckPasswordAsync(user, x.Password);
                })
                .WithMessage("Username or password is incorrect");
        });
    }
}
