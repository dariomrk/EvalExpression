using Lexer.Enums;
using Lexer.Extensions;
using Lexer.Types;

namespace Lexer.Functions
{
    internal static class TokenFunctions
    {
        internal static bool TryMatchNextToken(string expression, TokenType tokenType, out Token? output)
        {
            output = null;

            if (tokenType.GetRegex().Match(expression) is { Success: true } match)
            {
                output = new Token
                {
                    Lexeme = match.Value,
                    Type = tokenType,
                };
                return true;
            }

            return false;
        }

        internal static Token ToToken(string expression)
        {
            if (expression.Length is 0)
                return Token.EndOfFileToken;

            var tokensToCheck = new List<TokenType>
            {
                TokenType.Number,
                TokenType.Operator,
                TokenType.Parenthesis
            };

            foreach (var tokenType in tokensToCheck)
            {
                if (TryMatchNextToken(expression, tokenType, out var output))
                    return output!.Value;
            }

            return Token.Unknown;
        }
    }
}
