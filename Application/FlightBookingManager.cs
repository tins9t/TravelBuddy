using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;
using TravelBuddy.Core.Exceptions;
using TravelBuddy.Core.Interfaces;

namespace Application;

public class FlightBookingManager : IFlightBookingManager
{
    private readonly IFlightBookingRepository _flightBookingRepository;
    
    public FlightBookingManager(IFlightBookingRepository flightBookingRepository)
    {
        _flightBookingRepository = flightBookingRepository;
    }
    
    public async Task<Booking> CreateFlightBooking(Booking booking)
    {
    if (booking.DepartureDate <= DateTime.Today || booking.DepartureDate > DateTime.Today.AddMonths(6))
    {
        throw new InvalidDateException();
    }

    var availableSeats = await _flightBookingRepository.FindAvailableSeats(booking.DepartureDate, booking.FlightId);

    var seatNumber = FindAvailableSeat(booking.ClassType, availableSeats);

    booking.SeatNumber = seatNumber;

    var price = CalculateTotalPrice(booking.ClassType, booking.Meal, availableSeats.Count());
    booking.Price = price;

    return await _flightBookingRepository.CreateFlightBooking(booking);
    }

    public int FindAvailableSeat(TravelClass travelClass, List<FlightSeat> availableSeats)
    {
        if(availableSeats.Count == 0) throw new NoAvailableSeatException();
        var seat = availableSeats.FirstOrDefault(s => s.ClassType == travelClass);
        if(seat == null) throw new NoAvailableSeatInClassTypeException();
        return seat.SeatNumber;
    }

    public double CalculateTotalPrice(TravelClass travelClass, Meal meal, int availableSeats)
    {
        int basePrice = 1000;
        int totalSeats = 30;
        int bookedSeats = totalSeats - availableSeats;
        double occupancyRate = (double)bookedSeats / totalSeats;
        
        double loadMultiplier = 1.0;
        if (occupancyRate >= 0.9)
            loadMultiplier = 1.25;
        else if (occupancyRate >= 0.75)
            loadMultiplier = 1.15;
        else if (occupancyRate >= 0.5)
            loadMultiplier = 1.05;
        
        int classPrice = travelClass switch
        {
            TravelClass.Economy => 500,
            TravelClass.Business => 1000,
            TravelClass.First => 2000,
            _ => throw new ArgumentOutOfRangeException("Invalid travel class")
        };

        int mealPrice = meal switch
        {
            Meal.None => 0,
            Meal.Standard => 50,
            Meal.Vegetarian => 70,
            _ => throw new ArgumentOutOfRangeException("Invalid meal option")
        };
        
        int total = basePrice + classPrice + mealPrice;

        double price = total * loadMultiplier;

        return Math.Round(price, 2);
    }
}