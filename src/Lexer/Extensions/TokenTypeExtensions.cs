using Lexer.Enums;
using Lexer.Functions;
using System.Text.RegularExpressions;

namespace Lexer.Extensions
{
    internal static class TokenTypeExtensions
    {
        internal static Regex GetRegex(this TokenType type) => type switch
        {
            TokenType.Number => RegexFunctions.MatchNumberAtStart(),
            TokenType.Operator => RegexFunctions.MatchOperatorAtStart(),
            TokenType.Parenthesis => RegexFunctions.MatchParenthesisAtStart(),
            _ => throw new ArgumentException($"Cannot provide a {nameof(Regex)} for {nameof(TokenType)}.{type}."),
        };
    }
}
