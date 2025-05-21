using System;
using Reqnroll;
using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;
using TravelBuddy.UnitTest.Fixture;
using Xunit;

namespace TravelBuddy.Specs.StepDefinitions;

[Binding]
public sealed class FlightBookingManagerStepDefinitions
{
    FlightBookingManagerFixture _fixture;
    private int _availableSeats;
    private TravelClass _travelClass;
    private Meal _meal;
    private double _result;
    
    public FlightBookingManagerStepDefinitions(FlightBookingManagerFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Given("the amount of available seats are (.*)")]
    public void GivenTheAmountOfAvailableSeatsAre(int availableSeats)
    {
        _availableSeats = availableSeats;
    }

    [Given("the travel class is (.*)")]
    public void GivenTheTravelClassIs(TravelClass travelClass)
    {
        _travelClass = travelClass;
    }

    [Given("the meal is (.*)")]
    public void GivenTheMealIs(Meal meal)
    {
        _meal = meal;
    }
    
    [When("the total price is calculated")]
    public void WhenTheTotalPriceIsCalculated()
    {
        var flightBookingManager = _fixture.FlightBookingManager;
        _result = flightBookingManager.CalculateTotalPrice(_travelClass, _meal, _availableSeats);
    }

    [Then("the result should be (.*)")]
    public void ThenThePriceShouldBe(double result)
    {
        Assert.Equal(result, _result);
    }

    [When("the total price is calculated an error is thrown")]
    public void WhenTheTotalPriceIsCalculatedAnErrorIsThrown()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _fixture.FlightBookingManager.CalculateTotalPrice(_travelClass, _meal, _availableSeats));
    }
}