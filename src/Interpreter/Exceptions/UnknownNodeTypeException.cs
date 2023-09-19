namespace Interpreter.Exceptions
{
    public class UnknownNodeTypeException : Exception
    {
        internal UnknownNodeTypeException(string? message) : base(message) { }
    }
}
