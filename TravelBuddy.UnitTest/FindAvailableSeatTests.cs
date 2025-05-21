using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;
using TravelBuddy.Core.Exceptions;
using TravelBuddy.UnitTest.Fixture;

namespace TravelBuddy.UnitTest;

[Collection("FlightBookingManagerCollection collection")]
public class FindAvailableSeatTests
{
    FlightBookingManagerFixture _fixture;

    public FindAvailableSeatTests(FlightBookingManagerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void FindAvailableSeat_ShouldReturnSeatNumber_WhenSeatAvailableForClass()
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;
        var seats = new List<FlightSeat>()
        {
            new() { SeatNumber = 4, ClassType = TravelClass.First },
            new() { SeatNumber = 5, ClassType = TravelClass.First }
        };
        
        // Act
        var seatNumber = flightBookingManager.FindAvailableSeat(TravelClass.First, seats);

        // Assert
        Assert.Equal(4, seatNumber);
    }
    
    [Fact]
    public void FindAvailableSeat_ShouldThrowException_WhenNoSeatsAvailable()
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;
        var emptySeats = new List<FlightSeat> { };
        
        // Act & Assert
        var ex = Assert.Throws<NoAvailableSeatException>(() =>
            flightBookingManager.FindAvailableSeat(TravelClass.First, emptySeats));
        
        Assert.Contains("No available seat found.", ex.Message);
    }
    
    [Fact]
    public void FindAvailableSeat_ShouldThrowException_WhenNoSeatForClassTypeAvailable()
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;
        var emptySeats = new List<FlightSeat>
        {
            new() { SeatNumber = 4, ClassType = TravelClass.Business },
            new() { SeatNumber = 5, ClassType = TravelClass.Economy }
        };
        
        // Act & Assert
        var ex = Assert.Throws<NoAvailableSeatInClassTypeException>(() =>
            flightBookingManager.FindAvailableSeat(TravelClass.First, emptySeats));
        
        Assert.Contains("No available seat in specified travel class found.", ex.Message);
    }
}