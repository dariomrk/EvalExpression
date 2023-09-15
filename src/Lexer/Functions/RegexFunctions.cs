using Lexer.Constants;
using System.Text.RegularExpressions;

namespace Lexer.Functions
{
    internal static partial class RegexFunctions
    {
        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Number)]
        internal static partial Regex MatchNumberAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Plus)]
        internal static partial Regex MatchPlusAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Hyphen)]
        internal static partial Regex MatchHyphenAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Asterisk)]
        internal static partial Regex MatchAsteriskAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Slash)]
        internal static partial Regex MatchSlashAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Caret)]
        internal static partial Regex MatchCaretAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.OpenParenthesis)]
        internal static partial Regex MatchOpenParenthesisAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.CloseParenthesis)]
        internal static partial Regex MatchCloseParenthesisAtStart();

        [GeneratedRegex(RegexPattern.AtStart + RegexPattern.Whitespace)]
        internal static partial Regex MatchWhitespaceAtStart();
    }
}
