using Lexer.Enums;
using Parser.Exceptions;

namespace Parser.Functions
{
    internal static class ThrowHelper
    {
        internal static void UnexpectedEndOfExpression(TokenType expected) =>
            throw new SyntaxException($"Unexpected end of expression, expected {nameof(TokenType)} of {expected}.");

        internal static void UnexpectedEndOfExpression(HashSet<TokenType> expectedCollection)
        {
            var expected = expectedCollection.Aggregate("", (token, accumulator) => $"{accumulator}, {token}");

            throw new SyntaxException($"Unexpected end of expression, expected {nameof(TokenType)} of: [ {expected}].");
        }

        internal static void UnexpectedToken(string? lexeme, TokenType expected) =>
            throw new SyntaxException($"Unexpected token: '{lexeme ?? "NULL"}', expected {nameof(TokenType)} of {expected}.");

        internal static void ExpectedEndOfFile(string? lexeme) =>
            throw new SyntaxException($"Unexpected token: '{lexeme ?? "NULL"}', expected {nameof(TokenType)}.{nameof(TokenType.EndOfFile)}.");
    }
}