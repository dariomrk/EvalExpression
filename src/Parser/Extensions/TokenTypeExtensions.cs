using Lexer.Enums;

namespace Parser.Extensions
{
    internal static class TokenTypeExtensions
    {
        internal static byte GetPrecedence(this TokenType tokenType) => tokenType switch
        {
            TokenType.Plus => 1,
            TokenType.Hyphen => 1,
            TokenType.Asterisk => 2,
            TokenType.Slash => 2,
            TokenType.Caret => 3,
            TokenType.OpenParenthesis => 4,
            TokenType.CloseParenthesis => 4,
            _ => throw new ArgumentException($"Cannot provide precedence for {nameof(TokenType)}.{tokenType}."),
        };
    }
}
