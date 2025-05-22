using TravelBuddy.Core.Entities;

namespace TravelBuddy.Core.Interfaces;

public interface IFlightBookingRepository
{
    public Task<List<FlightSeat>> FindAvailableSeats(DateTime departureDate, int flightId);
    public Task<Booking> CreateFlightBooking(Booking booking);
}