using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;
using TravelBuddy.Core.Exceptions;
using TravelBuddy.UnitTest.Fixture;
using TravelBuddy.UnitTest.TestData;

namespace TravelBuddy.UnitTest;

[Collection("FlightBookingManagerCollection collection")]
public class CreateFlightBookingTests
{
    FlightBookingManagerFixture _fixture;
    
    public CreateFlightBookingTests(FlightBookingManagerFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Theory]
    [MemberData(nameof(TestDataDates.ValidDates), MemberType = typeof(TestDataDates))]
    public async Task CreateFlightBooking_ShouldCreateBooking_ForValidDepartureDates(DateTime departureDate)
    {
        // Arrange
        var booking = new Booking
        {
            Id = 1,
            DepartureDate = departureDate,
            FlightId = 1,
            ClassType = TravelClass.Economy,
            Meal = Meal.None
        };

        var flightBookingManager = _fixture.FlightBookingManager;

        // Act
        var createdBooking = await flightBookingManager.CreateFlightBooking(booking);
        
        // Assert
        Assert.Equal(booking.Id, createdBooking.Id);
    }
    
    [Theory]
    [MemberData(nameof(TestDataDates.InvalidDates), MemberType = typeof(TestDataDates))]
    public async Task CreateFlightBooking_ShouldThrowInvalidDateException_ForInvalidDepartureDates(DateTime departureDate)
    {
        // Arrange
        var booking = new Booking
        {
            DepartureDate = departureDate,
            FlightId = 1,
            ClassType = TravelClass.Economy,
            Meal = Meal.None
        };

        var flightBookingManager = _fixture.FlightBookingManager;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidDateException>(() => flightBookingManager.CreateFlightBooking(booking));
        Assert.Equal("The provided date is invalid.", exception.Message); 
    }
}