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
        var booking = new Booking
        {
            DepartureDate = departureDate,
            FlightId = 1,
            ClassType = TravelClass.Economy,
            Meal = Meal.None
        };

        var flightBookingManager = _fixture.FlightBookingManager;

        var exception = await Record.ExceptionAsync(() => flightBookingManager.CreateFlightBooking(booking));
        Assert.Null(exception);
    }
    
    [Theory]
    [MemberData(nameof(TestDataDates.InvalidDates), MemberType = typeof(TestDataDates))]
    public async Task CreateFlightBooking_ShouldThrowInvalidDateException_ForInvalidDepartureDates(DateTime departureDate)
    {
        var booking = new Booking
        {
            DepartureDate = departureDate,
            FlightId = 1,
            ClassType = TravelClass.Economy,
            Meal = Meal.None
        };

        var flightBookingManager = _fixture.FlightBookingManager;

        var exception = await Assert.ThrowsAsync<InvalidDateException>(() => flightBookingManager.CreateFlightBooking(booking));
        Assert.Equal("The provided date is invalid.", exception.Message); 
    }
}