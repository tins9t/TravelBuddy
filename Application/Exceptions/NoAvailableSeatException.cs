namespace TravelBuddy.Core.Exceptions;

public class NoAvailableSeatException : Exception
{
    public NoAvailableSeatException() : base ("No available seat found.") { }
    public NoAvailableSeatException(string message) : base(message) { }
}