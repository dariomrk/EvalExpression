using Lexer.Enums;
using Parser.Enums;

namespace Parser.Extensions
{
    internal static class TokenTypeExtensions
    {
        internal static NodeType ToBinaryNodeType(this TokenType type) => type switch
        {
            TokenType.Plus => NodeType.Add,
            TokenType.Hyphen => NodeType.Subtract,
            TokenType.Asterisk => NodeType.Multiply,
            TokenType.Slash => NodeType.Divide,
            TokenType.Caret => NodeType.Exponentiate,
            _ => throw new ArgumentException($"Cannot provide a binary {nameof(NodeType)} for {nameof(TokenType)}.{type}.")
        };

        internal static NodeType ToUnaryNodeType(this TokenType type) => type switch
        {
            TokenType.Plus => NodeType.Positive,
            TokenType.Hyphen => NodeType.Negative,
            _ => throw new ArgumentException($"Cannot provide a unary {nameof(NodeType)} for {nameof(TokenType)}.{type}.")
        };
    }
}
