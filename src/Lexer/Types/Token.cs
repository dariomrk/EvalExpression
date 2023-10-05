using Lexer.Enums;

namespace Lexer.Types
{
    public readonly record struct Token
    {
        public string? Lexeme { get; init; }
        public TokenType Type { get; init; }

        public Token(TokenType type, string? lexeme = default)
        {
            Lexeme = lexeme;
            Type = type;
        }

        public override string ToString() =>
            $"{{ Lexeme = {Lexeme ?? "NULL"}, TokenType = {Type} }}";

        public static Token EndOfFileToken =>
            new()
            {
                Lexeme = null,
                Type = TokenType.EndOfFile,
            };

        public static Token Unknown =>
            new()
            {
                Lexeme = null,
                Type = TokenType.Unknown,
            };
    }
}