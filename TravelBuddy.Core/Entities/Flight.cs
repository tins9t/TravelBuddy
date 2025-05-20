namespace TravelBuddy.Core.Entities;

public class Flight
{
    public int Id { get; set; }
    public string DepartureAirport { get; set; }
    public string Destination { get; set; }
    public List<FlightSeat> Seats { get; set; } = new();
}