using Asp.Versioning;
using BookBeacon.API.Helpers.Facades.ReservationControllerFacade;
using BookBeacon.API.Helpers.InputValidator;
using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookBeacon.API.Controllers;


[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/reservations")]
public class ReservationController : ControllerBase
{
    private readonly IReservationControllerFacade _reservationControllerFacade;
    
    public ReservationController(IReservationControllerFacade reservationControllerFacade)
    {
        _reservationControllerFacade = reservationControllerFacade;
    }

    [HttpGet(Name = "GetReservations")]
    [HttpHead]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    public async Task<ActionResult<PagedList<ReservationDto>>> GetReservations(
        [FromQuery] ReservationResourceParameters resourceParameters)
    {
        var reservations = await _reservationControllerFacade.ReservationManager
            .GetAllAsync(resourceParameters);
        
        _reservationControllerFacade.PaginationHelper
            .CreateMetaDataHeader(
                reservations, resourceParameters, Response.Headers, Url, "GetReservations");
        
        return Ok(reservations);
    }
    
    [HttpGet("{reservationId}", Name = "GetReservation")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    public async Task<ActionResult<ReservationDto>> GetReservation(int reservationId)
    {
        var reservation = await _reservationControllerFacade.ReservationManager
            .GetByIdAsync(reservationId);
        
        if (reservation == null)
            return NotFound();
        
        return Ok(reservation);
    }
    
    [HttpPost(Name = "CreateReservation")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    public async Task<ActionResult<ReservationDto>> CreateReservation(
        [FromBody] CreateReservationDto reservationDto)
    {
        var validationResult = await _reservationControllerFacade.ReservationValidator
            .ValidateAsync(reservationDto);
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        var reservation = await _reservationControllerFacade.ReservationManager
            .CreateAsync(reservationDto);
        
        return CreatedAtRoute(
            "GetReservation",
            new { reservationId = reservation.Id },
            reservation);
    }
    
    [HttpPost("{reservationId}/cancel", Name = "CancelReservation")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult> CancelReservation(int reservationId)
    {
        var reservation = await _reservationControllerFacade.ReservationManager
            .GetByIdAsync(reservationId);
        
        if (reservation == null)
            return NotFound();
        
        await _reservationControllerFacade.ReservationManager
            .CancelAsync(reservationId);
        
        return NoContent();
    }
    
    [HttpDelete("{reservationId}", Name = "DeleteReservation")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult> DeleteReservation(int reservationId)
    {
        var reservation = _reservationControllerFacade.ReservationManager
            .GetByIdAsync(reservationId);
        
        if (reservation == null)
            return NotFound();
        
        await _reservationControllerFacade.ReservationManager
            .DeleteAsync(reservationId);
        
        return NoContent();
    }
    
    [HttpOptions]
    public IActionResult GetReservationOptions()
    {
        Response.Headers.Append("Allow", "GET, POST, DELETE, HEAD, OPTIONS");
        return Ok();
    }
}
