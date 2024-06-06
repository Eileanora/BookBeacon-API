using Asp.Versioning;
using BookBeacon.API.Helpers.Facades.CopyControllerFacade;
using BookBeacon.API.Helpers.InputValidator;
using BookBeacon.BL.DTOs.CopyDTOs;
using BookBeacon.BL.Helpers.Mappers;
using BookBeacon.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace BookBeacon.API.Controllers;


[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/copies")]
public class CopyController : ControllerBase
{
    private readonly ICopyControllerFacade _copyControllerFacade;
    
    public CopyController(ICopyControllerFacade copyControllerFacade)
    {
        _copyControllerFacade = copyControllerFacade;
    }
    
    [HttpGet(Name = "GetCopies")]
    public async Task<ActionResult<PagedList<CopyDto>>> GetCopies(
        [FromQuery] CopyResourceParameters resourceParameters)
    {
        var copies = await _copyControllerFacade.CopyManager
            .GetAllAsync(resourceParameters);
        
        _copyControllerFacade.PaginationHelper.CreateMetaDataHeader(
            copies, resourceParameters, Response.Headers, Url, "GetCopies");
        
        return Ok(copies);
    }
    
    [HttpGet("{copyId}", Name = "GetCopy")]
    public async Task<ActionResult<CopyDto>> GetCopy(int copyId)
    {
        var copy = await _copyControllerFacade.CopyManager
            .GetByIdAsync(copyId);
        
        if (copy == null)
            return NotFound();
        
        return Ok(copy);
    }
    
    [HttpPost]
    public async Task<ActionResult<CopyDto>> CreateCopyAsync(
        [FromBody] CopyDto copy)
    {
        var validationResult = await _copyControllerFacade.CopyValidator.ValidateAsync(
            copy,
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        var newCopy = await _copyControllerFacade.CopyManager.CreateAsync(copy);
        return CreatedAtRoute("GetCopy",
            new { copyId = newCopy.Id },
            newCopy);
    }
    
    [HttpPatch("{copyId}")]
    public async Task<IActionResult> UpdateCopy(
        int copyId,
        JsonPatchDocument<CopyDto> patchDocument)
    {
        var copy = await _copyControllerFacade.CopyManager.GetByIdAsync(copyId);
        
        if (copy == null)
            return NotFound();
        
        var copyToPatch = copy.ToUpdateDto();
        patchDocument.ApplyTo(copyToPatch, ModelState);
        
        var validationResult = await _copyControllerFacade.CopyValidator.ValidateAsync(
            copyToPatch,
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        await _copyControllerFacade.CopyManager.UpdateAsync(copyId, copyToPatch);
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCopy(int copyId)
    {
        var deleted = await _copyControllerFacade.CopyManager.DeleteAsync(copyId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
    
}
