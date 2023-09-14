using Lexer.Constants;
using System.Text.RegularExpressions;

namespace Lexer.Functions
{
    internal static partial class RegexFunctions
    {
        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Number)]
        internal static partial Regex MatchNumberAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Operator)]
        internal static partial Regex MatchOperatorAtStart();

        [GeneratedRegex(RegexPattern.Whitespace)]
        internal static partial Regex MatchWhiteSpace();

        internal static string RemoveWhitespace(string expression) =>
            MatchWhiteSpace().Replace(expression, "");
    }
}
