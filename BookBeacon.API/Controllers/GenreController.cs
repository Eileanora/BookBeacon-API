using BookBeacon.API.Helpers.Facades.GenreControllerFacade;
using BookBeacon.API.Helpers.InputValidator;
using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Asp.Versioning;
using BookBeacon.BL.Helpers.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace BookBeacon.API.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreControllerFacade _genreControllerFacade;

    public GenreController(IGenreControllerFacade genreControllerFacade)
    {
        _genreControllerFacade = genreControllerFacade;
    }
    
    [HttpGet(Name = "GetAllGenres")]
    [HttpHead]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> GetAllGenresAsync(
        [FromQuery] GenreResourceParameters resourceParameters)
    {
        var genres = await _genreControllerFacade
            .GenreManager.GetAllAsync(resourceParameters);
        
        _genreControllerFacade.PaginationHelper
            .CreateMetaDataHeader(
                genres, resourceParameters, Response.Headers, Url, "GetAllGenres");
        
        return Ok(genres);
    }
    
    [HttpGet("{genreId}", Name = "GetGenre")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> GetGenreByIdAsync(int genreId)
    {
        var genre = await _genreControllerFacade.GenreManager.GetByIdAsync(genreId);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult<GenreDto>> CreateGenreAsync(
        [FromBody] GenreDto genre)
    {
        var validationResult = await _genreControllerFacade.GenreValidator.ValidateAsync(
            genre,
            options => options.IncludeRuleSets("CreateInput"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        var createdGenre = await _genreControllerFacade.GenreManager
            .CreateAsync(genre);
        
        if (createdGenre == null)
            return BadRequest();
        
        return CreatedAtRoute(
            "GetGenre",
            new { genreId = createdGenre.Id },
            createdGenre);
    }
    
    [HttpDelete("{genreId}")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> DeleteGenreAsync(int genreId)
    {
        var deleted = await _genreControllerFacade.GenreManager
            .DeleteAsync(genreId);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
    
    [HttpOptions]
    public IActionResult GetGenreOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,PATCH,DELETE,OPTIONS");
        return Ok();
    }
    
    [HttpPatch("{genreId}")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> UpdateGenreAsync(
        int genreId,
        JsonPatchDocument<GenreDto> patchDocument)
    {
        var genre = await _genreControllerFacade.GenreManager.GetByIdAsync(genreId);
        if (genre == null)
            return NotFound();

        var genreToPatch = genre.ToUpdateDto();
        patchDocument.ApplyTo(genreToPatch, ModelState);
        
        var validationResult = await _genreControllerFacade.GenreValidator.ValidateAsync(
            genreToPatch,
            options => options.IncludeRuleSets("UpdateInput"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        await _genreControllerFacade.GenreManager.UpdateAsync(genreId, genreToPatch);
        return NoContent();
    }
}
