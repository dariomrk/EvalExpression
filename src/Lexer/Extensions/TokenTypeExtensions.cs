using Lexer.Enums;
using Lexer.Functions;
using System.Text.RegularExpressions;

namespace Lexer.Extensions
{
    internal static class TokenTypeExtensions
    {
        internal static Regex GetRegex(this TokenType type) => type switch
        {
            TokenType.Whitespace => RegexFunctions.MatchWhitespaceAtStart(),
            TokenType.Number => RegexFunctions.MatchNumberAtStart(),
            TokenType.Plus => RegexFunctions.MatchPlusAtStart(),
            TokenType.Hyphen => RegexFunctions.MatchHyphenAtStart(),
            TokenType.Asterisk => RegexFunctions.MatchAsteriskAtStart(),
            TokenType.Slash => RegexFunctions.MatchSlashAtStart(),
            TokenType.Caret => RegexFunctions.MatchCaretAtStart(),
            TokenType.OpenParenthesis => RegexFunctions.MatchOpenParenthesisAtStart(),
            TokenType.CloseParenthesis => RegexFunctions.MatchCloseParenthesisAtStart(),
            _ => throw new ArgumentException($"Cannot provide a {nameof(Regex)} for {nameof(TokenType)}.{type}.")
        };
    }
}
