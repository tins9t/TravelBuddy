using Microsoft.EntityFrameworkCore;
using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Interfaces;

namespace Infrastructure.Repositories;

public class FlightBookingRepository : IFlightBookingRepository
{
    private readonly AppDbContext _context;

    public FlightBookingRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<FlightSeat>> FindAvailableSeats(DateTime departureDate, int flightId)
    {
        var bookedSeats = await _context.Bookings
            .Where(b => b.FlightId == flightId && b.DepartureDate.Date == departureDate.Date)
            .Select(b => new { b.SeatNumber, b.ClassType })
            .ToListAsync();

        return _context.FlightSeats
            .Where(fs => fs.FlightId == flightId)
            .AsEnumerable()
            .Where(fs => !bookedSeats.Any(b => b.SeatNumber == fs.SeatNumber && b.ClassType == fs.ClassType)).ToList();
    }

    public async Task<Booking> CreateFlightBooking(Booking booking)
    {
       var createdBooking = _context.Bookings.Add(booking);
       await _context.SaveChangesAsync();
       return createdBooking.Entity;
    }
}