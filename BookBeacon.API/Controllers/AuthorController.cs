using Asp.Versioning;
using BookBeacon.API.Helpers.Facades.AuthorControllerFacade;
using BookBeacon.API.Helpers.InputValidator;
using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace BookBeacon.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorControllerFacade _authorControllerFacade;
    public AuthorController(IAuthorControllerFacade authorControllerFacade)
    {
        _authorControllerFacade = authorControllerFacade;
    }
    
    [HttpGet(Name = "GetAllAuthors")]
    [HttpHead]
    public async Task<IActionResult> GetAllAuthorsAsync(
        [FromQuery] AuthorResourceParameters resourceParameters)
    {
        var authors = await _authorControllerFacade.AuthorManager.GetAllAsync(resourceParameters);
        
        var paginationHelper = new PaginationHelper<AuthorDto, AuthorResourceParameters>();
        paginationHelper.CreateMetaDataHeader(authors,
            resourceParameters,
            Response.Headers,
            Url, "GetAllAuthors");
    
        return Ok(authors);
    }
    
    [HttpGet("{authorId}", Name = "GetAuthor")]
    public async Task<IActionResult> GetAuthorByIdAsync(int authorId)
    {
        var author = await _authorControllerFacade.AuthorManager.GetByIdAsync(authorId);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }
    
    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthorAsync(
        [FromBody] AuthorDto author)
    {
        var validationResult = await _authorControllerFacade.AuthorValidator.ValidateAsync(
            author,
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        var createdAuthor = await _authorControllerFacade.AuthorManager
            .CreateAsync(author);
        
        if (createdAuthor == null)
            return BadRequest();
        
        return CreatedAtRoute(
            "GetAuthor",
            new { authorId = createdAuthor.Id },
            createdAuthor);
    }
    
    
    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthorAsync(int authorId)
    {
        var deleted = await _authorControllerFacade.AuthorManager.DeleteAsync(authorId);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    [HttpOptions]
    public IActionResult GetGenreOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,PATCH,DELETE,OPTIONS");
        return Ok();
    }
    
    [HttpPatch("{authorId}")]
    public async Task<IActionResult> PartiallyUpdateAuthorAsync(
        int authorId,
        JsonPatchDocument<AuthorDto> patchDocument)
    {
        var author = await _authorControllerFacade.AuthorManager.GetByIdAsync(authorId);
        if (author == null)
        {
            return NotFound();
        }

        var authorToPatch = author.ToUpdateDto();
        patchDocument.ApplyTo(authorToPatch, ModelState);
        
        var validationResult = await _authorControllerFacade.AuthorValidator.ValidateAsync(
            authorToPatch,
            options => options.IncludeRuleSets("Input"));

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        await _authorControllerFacade.AuthorManager.UpdateAsync(authorId, authorToPatch);
    
        return NoContent();
    }
    
}
