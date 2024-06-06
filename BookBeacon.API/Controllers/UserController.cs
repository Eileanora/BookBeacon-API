using Asp.Versioning;
using BookBeacon.API.Helpers.Facades.UserControllerFacade;
using BookBeacon.API.Helpers.InputValidator;
using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.Models.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace BookBeacon.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class UserController : ControllerBase
{
    private readonly IUserControllerFacade _userControllerFacade;
    
    public UserController(IUserControllerFacade userControllerFacade)
    {
        _userControllerFacade = userControllerFacade;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] UserForRegisterDto userForRegisterDto)
    {
        // var validationResult = await _userControllerFacade.RegisterValidator.ValidateAsync(
        //     userForRegisterDto,
        //     options => options.IncludeRuleSets("Input"));
        //
        // if (!validationResult.IsValid)
        // {
        //     validationResult.AddToModelState(this.ModelState);
        //     return BadRequest(this.ModelState);
        // }
        var result = await _userControllerFacade.AuthService.RegisterAsync(userForRegisterDto);
        if (!result.Succeeded)
        {
            result.AddIdentityProblemsToModelState(this.ModelState);
            return ValidationProblem(this.ModelState);
        }
        
        await _userControllerFacade.AuthService.AddToRoleAsync(userForRegisterDto.UserName, "User");
        
        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginAsync(
        [FromBody] UserForLoginDto userForLoginDto)
    {
        var validationResult = await _userControllerFacade.LoginValidator.ValidateAsync(
            userForLoginDto,
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }
        
        var user = await _userControllerFacade.AuthService.LoginAsync(userForLoginDto);
        if (user == null)
            return Unauthorized();
        
        return Ok(user);
    }
    
    [HttpGet("info")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult<UserInfoDto>> GetUserAsync()
    {
        var user = await _userControllerFacade.AuthService.GetUserInfoAsync();
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }
}
