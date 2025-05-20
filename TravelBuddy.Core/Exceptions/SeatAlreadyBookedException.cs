namespace TravelBuddy.Core.Exceptions;


public class SeatAlreadyBookedException : Exception
{
    public SeatAlreadyBookedException() : base("The seat is already taken.") { }

    public SeatAlreadyBookedException(string message) : base(message) { }
}