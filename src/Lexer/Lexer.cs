using Lexer.Enums;
using Lexer.Functions;
using Lexer.Types;

namespace Lexer
{
    public static class Lexer
    {
        public static IEnumerable<Token> Tokenize(string expression)
        {
            var position = 0;

            while (position <= expression.Length)
            {
                var token = TokenFunctions.ToToken(expression[position..]);

                yield return token;

                if (token.Type is TokenType.EndOfFile)
                    yield break;

                position += token.Lexeme!.Length;
            }
        }
    }
}
