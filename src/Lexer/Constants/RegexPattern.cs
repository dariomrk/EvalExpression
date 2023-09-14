namespace Lexer.Constants
{
    internal static partial class RegexPattern
    {
        internal const string AtStart = "^";
        internal const string Number = @"[0-9]+(\.[0-9]+)?";
        internal const string Operator = "[-+*/^()]";
        internal const string Whitespace = @"\s+";
    }
}
