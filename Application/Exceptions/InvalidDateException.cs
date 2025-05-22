namespace TravelBuddy.Core.Exceptions;

public class InvalidDateException : Exception
{
    public InvalidDateException () : base("The provided date is invalid.") { }
    public InvalidDateException (string message) : base(message) { }
}