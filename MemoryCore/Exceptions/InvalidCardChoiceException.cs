namespace MemoryCore.Exceptions;

public class InvalidCardChoiceException : Exception
{
    public InvalidCardChoiceException()
    {
    }

    public InvalidCardChoiceException(string message)
        : base(message)
    {
    }

    public InvalidCardChoiceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}