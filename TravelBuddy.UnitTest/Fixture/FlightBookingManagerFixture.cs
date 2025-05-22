using Application;
using Moq;
using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;
using TravelBuddy.Core.Interfaces;

namespace TravelBuddy.UnitTest.Fixture;

public class FlightBookingManagerFixture : IDisposable
{
    public FlightBookingManager FlightBookingManager { get; }
    public Mock<IFlightBookingRepository> mockFlightBookingRepository;

    public FlightBookingManagerFixture()
    {
        mockFlightBookingRepository = new Mock<IFlightBookingRepository>();

        var testFlight = new Flight
        {
            Id = 1,
            DepartureAirport = "CPH",
            Destination = "SPAIN",
            Seats = new List<FlightSeat>()
        };

        for (int i = 1; i <= 10; i++)
        {
            testFlight.Seats.Add(new FlightSeat { SeatNumber = i, ClassType = TravelClass.First });
            testFlight.Seats.Add(new FlightSeat { SeatNumber = i, ClassType = TravelClass.Business });
            testFlight.Seats.Add(new FlightSeat { SeatNumber = i, ClassType = TravelClass.Economy });
        }
        
        mockFlightBookingRepository
            .Setup(repo => repo.FindAvailableSeats(It.IsAny<DateTime>(), It.IsAny<int>()))
            .ReturnsAsync(testFlight.Seats);
        
        mockFlightBookingRepository
            .Setup(repo => repo.CreateFlightBooking(It.IsAny<Booking>()))
            .ReturnsAsync((Booking b) => b);

        FlightBookingManager = new FlightBookingManager(mockFlightBookingRepository.Object);
    }

    public void Dispose()
    {
    }
}