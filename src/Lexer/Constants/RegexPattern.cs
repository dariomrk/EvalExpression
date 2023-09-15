namespace Lexer.Constants
{
    internal static partial class RegexPattern
    {
        internal const string AtStart = "^";
        internal const string Number = @"[0-9]+(\.[0-9]+)?";
        internal const string Plus = "[+]";
        internal const string Hyphen = "[-]";
        internal const string Asterisk = "[*]";
        internal const string Slash = "[/]";
        internal const string Caret = "[\\^]";
        internal const string OpenParenthesis = "[(]";
        internal const string CloseParenthesis = "[)]";
        internal const string Whitespace = @"\s{1,}";
    }
}
