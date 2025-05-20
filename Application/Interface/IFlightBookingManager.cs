using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;

namespace Application.Interface;

public interface IFlightBookingManager
{
    public Task CreateFlightBooking(Booking booking);
    public int FindAvailableSeat(TravelClass travelClass, List<FlightSeat> availableSeats);
    public double CalculateTotalPrice(TravelClass travelClass, Meal meal, int availableSeats);
}