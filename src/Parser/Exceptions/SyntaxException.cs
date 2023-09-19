namespace Parser.Exceptions
{
    public sealed class SyntaxException : Exception
    {
        internal SyntaxException() { }
        internal SyntaxException(string? message) : base(message) { }
    }
}
