using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;

namespace TravelBuddy.UnitTest.TestData;

public class FindAvailabeSeatTestData
{
    public static IEnumerable<object[]> AvailableSeats =>
    new List<object[]>
    {
        new object[]
        {
            TravelClass.First,
            new List<FlightSeat>
            {
                new FlightSeat { SeatNumber = 4, ClassType = TravelClass.First },
                new FlightSeat { SeatNumber = 5, ClassType = TravelClass.First }
            },
            4
        },
        new object[]
        {
            TravelClass.Business,
            new List<FlightSeat>
            {
                new FlightSeat { SeatNumber = 5, ClassType = TravelClass.First },
                new FlightSeat { SeatNumber = 5, ClassType = TravelClass.Business },
                new FlightSeat { SeatNumber = 6, ClassType = TravelClass.Business },
            },
            5
        },
        new object[]
        {
            TravelClass.Economy,
            new List<FlightSeat>
            {
                new FlightSeat { SeatNumber = 1, ClassType = TravelClass.Business },
                new FlightSeat { SeatNumber = 2, ClassType = TravelClass.Economy },
                new FlightSeat { SeatNumber = 3, ClassType = TravelClass.Economy }
            },
            2 
        },
    };

    public static IEnumerable<object[]> NoAvailableSeatData =>
    new List<object[]>
    {
        new object[]
        {
            TravelClass.First,
            new List<FlightSeat>
            {
                new FlightSeat { SeatNumber = 5, ClassType = TravelClass.Business },
                new FlightSeat { SeatNumber = 6, ClassType = TravelClass.Economy },
                new FlightSeat { SeatNumber = 7, ClassType = TravelClass.Economy }
            }
        },
        new object[]
        {
            TravelClass.First,
            new List<FlightSeat>() 
        },
        new object[]
        {
            TravelClass.Business,
            new List<FlightSeat>
            {
                new FlightSeat { SeatNumber = 5, ClassType = TravelClass.Economy },
                new FlightSeat { SeatNumber = 6, ClassType = TravelClass.Economy },
                new FlightSeat { SeatNumber = 7, ClassType = TravelClass.Economy }
            }
        },
        new object[]
        {
            TravelClass.Business,
            new List<FlightSeat>() 
        }
    }; 
}