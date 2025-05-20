using Microsoft.EntityFrameworkCore;
using TravelBuddy.Core.Entities;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<FlightSeat> FlightSeats { get; set; }
}