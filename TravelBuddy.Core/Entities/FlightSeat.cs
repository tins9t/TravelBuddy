using TravelBuddy.Core.Enums;

namespace TravelBuddy.Core.Entities;

public class FlightSeat
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public TravelClass ClassType { get; set; }
    public int SeatNumber { get; set; }
}
