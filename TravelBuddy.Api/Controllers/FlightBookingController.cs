using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Exceptions;

namespace TravelBuddy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightBookingController : ControllerBase
{
    private readonly IFlightBookingManager _flightBookingManager;
    
    public FlightBookingController(IFlightBookingManager flightBookingManager)
    {
        _flightBookingManager = flightBookingManager;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateFlightBooking(Booking booking)
    {
        try
        {
            await _flightBookingManager.CreateFlightBooking(booking);
            return StatusCode(201, booking);
        }
        catch (InvalidDateException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (NoAvailableSeatException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "An unexpected error occurred." });
        }
    }
}