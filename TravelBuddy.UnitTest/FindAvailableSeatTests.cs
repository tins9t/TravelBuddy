using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;
using TravelBuddy.Core.Exceptions;
using TravelBuddy.UnitTest.Fixture;
using TravelBuddy.UnitTest.TestData;

namespace TravelBuddy.UnitTest;

[Collection("FlightBookingManagerCollection collection")]
public class FindAvailableSeatTests
{
    FlightBookingManagerFixture _fixture;

    public FindAvailableSeatTests(FlightBookingManagerFixture fixture)
    {
        _fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(FindAvailabeSeatTestData.AvailableSeats), MemberType = typeof(FindAvailabeSeatTestData))]    
    public void FindAvailableSeat_ShouldReturnSeatNumber_WhenSeatAvailableForClass(TravelClass travelClass, List<FlightSeat> seats, int expectedNumber)
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;

        // Act
        var seatNumber = flightBookingManager.FindAvailableSeat(travelClass, seats);

        // Assert
        Assert.Equal(expectedNumber, seatNumber);
    }
    
    [Theory]
    [MemberData(nameof(FindAvailabeSeatTestData.NoAvailableSeatData), MemberType = typeof(FindAvailabeSeatTestData))] 
    public void FindAvailableSeat_ShouldThrowException_WhenNoSeatsAvailable(TravelClass travelClass, List<FlightSeat> seats)
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;
        // Act & Assert
        var ex = Assert.Throws<NoAvailableSeatException>(() =>
            flightBookingManager.FindAvailableSeat(travelClass, seats));
        
        Assert.Contains("No available seat found.", ex.Message);
    }
}