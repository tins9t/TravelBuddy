using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;

namespace Infrastructure.Interface;

public interface IFlightBookingRepository
{
    public Task<List<FlightSeat>> FindAvailableSeats(DateTime departureDate, int flightId);
    public Task CreateFlightBooking(Booking booking);
}