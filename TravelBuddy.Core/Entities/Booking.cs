using System.ComponentModel.DataAnnotations;
using TravelBuddy.Core.Enums;
namespace TravelBuddy.Core.Entities;

public class Booking
{
    [Key]
    public int Id { get; set; }
    public int FlightId { get; set; }
    public DateTime DepartureDate { get; set; }
    public int CustomerId { get; set; }
    public TravelClass ClassType { get; set; } 
    public int SeatNumber { get; set; }  
    public Meal Meal { get; set; }
    public double Price { get; set; }
}