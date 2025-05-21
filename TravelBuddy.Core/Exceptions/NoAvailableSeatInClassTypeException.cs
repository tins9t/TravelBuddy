namespace TravelBuddy.Core.Exceptions;
public class NoAvailableSeatInClassTypeException : Exception
{
    public NoAvailableSeatInClassTypeException() : base ("No available seat in specified travel class found.") { }
    public NoAvailableSeatInClassTypeException(string message) : base(message) { }
}