using TravelBuddy.Core.Entities;
using TravelBuddy.Core.Enums;

namespace Infrastructure;

public class DbInitializer 
{
    public void Initialize(AppDbContext context)
    {

        context.Database.EnsureDeleted();

        context.Database.EnsureCreated();

        if (context.Bookings.Any())
        {
            return; 
        }

        var customers = new List<Customer>()
        {
            new ()
            {
                FirstName = "Jane",
                LastName = "Doe",
            },
            new ()
            {
                FirstName = "John",
                LastName = "Smith"
            },
            new ()
            {
            FirstName = "Alice",
            LastName = "Doe" 
            },
            new ()
            {
                FirstName = "Bob",
                LastName = "Smith" 
            },
        };
        
        context.Customers.AddRange(customers);
        
        var flight = new Flight()
        {
            DepartureAirport = "CPH",
            Destination = "SPAIN",
            Seats = new List<FlightSeat>()
        };

        for (int i = 1; i <= 10; i++)
        {
            flight.Seats.Add(new FlightSeat { SeatNumber = i, ClassType = TravelClass.First });
            flight.Seats.Add(new FlightSeat { SeatNumber = i, ClassType = TravelClass.Business });
            flight.Seats.Add(new FlightSeat { SeatNumber = i, ClassType = TravelClass.Economy });
        }
        
        context.Flights.Add(flight);

        var bookings = new List<Booking>();

        for (int i = 1; i <= 10; i++)
        {
            bookings.Add(new Booking()
            {
                DepartureDate = DateTime.Today.AddDays(4),
                CustomerId = 1,
                FlightId = 1,
                SeatNumber = i,
                ClassType = TravelClass.First
            });
        }

        for (int i = 1; i <= 5; i++)
        {
            bookings.Add(new Booking()
            {
                DepartureDate = DateTime.Today.AddDays(4),
                CustomerId = 2,
                FlightId = 1,
                SeatNumber = i,
                ClassType = TravelClass.Business
            });
        }

        for (int i = 1; i <= 5; i++)
        {
            bookings.Add(new Booking()
            {
                DepartureDate = DateTime.Today.AddDays(4),
                CustomerId = 3,
                FlightId = 1,
                SeatNumber = i,
                ClassType = TravelClass.Economy
            });
        }

        context.Bookings.AddRange(bookings);
        context.SaveChanges();

        context.SaveChanges();
    }
}