using TravelBuddy.Core.Enums;
using TravelBuddy.UnitTest.Fixture;
using TravelBuddy.UnitTest.TestData;

namespace TravelBuddy.UnitTest;

[Collection("FlightBookingManagerCollection collection")]
public class PriceCalculationTests
{
    FlightBookingManagerFixture _fixture;

    public PriceCalculationTests(FlightBookingManagerFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Theory]
    [MemberData(nameof(PriceCalculationTestData.PriceCalculationData),  MemberType= typeof(PriceCalculationTestData))]
    public async Task CalculateTotalPrice_ShouldReturnCorrectPrice(TravelClass travelClass, Meal meal, int availableSeats, double expectedPrice)
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;

        // Act
        var result = flightBookingManager.CalculateTotalPrice(travelClass, meal, availableSeats);

        // Assert
        Assert.Equal(expectedPrice, result);
    }

    [Fact]
    public async Task CalculateTotalPrice_ShouldThrowException_WhenInvalidMeal()
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;

        // Act & Assert
        var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            Task.Run(() => flightBookingManager.CalculateTotalPrice(TravelClass.Economy, (Meal)999, 10)));

        Assert.Contains("Invalid meal option", ex.Message);
    }

    [Fact]
    public async Task CalculateTotalPrice_ShouldThrowException_WhenInvalidClassType()
    {
        // Arrange
        var flightBookingManager = _fixture.FlightBookingManager;

        // Act & Assert
        var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            Task.Run(() => flightBookingManager.CalculateTotalPrice((TravelClass)999, Meal.None, 10)));

        Assert.Contains("Invalid travel class", ex.Message);
    }

}