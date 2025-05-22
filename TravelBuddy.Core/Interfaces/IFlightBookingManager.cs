using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;

namespace TravelBuddy.Core.Interfaces;

public interface IFlightBookingManager
{
    public Task<Booking> CreateFlightBooking(Booking booking);
    public int FindAvailableSeat(TravelClass travelClass, List<FlightSeat> availableSeats);
    public double CalculateTotalPrice(TravelClass travelClass, Meal meal, int availableSeats);
}