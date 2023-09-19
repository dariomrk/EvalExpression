namespace Parser.Exceptions
{
    public sealed class SyntaxException : Exception
    {
        internal SyntaxException(string? message) : base(message) { }
    }
}
