using Lexer.Enums;
using Lexer.Functions;
using Lexer.Interfaces;
using Lexer.Types;

namespace Lexer
{
    public class Lexer : ILexer
    {
        public IEnumerable<Token> Tokenize(string inputExpression)
        {
            int position = 0;
            var expression = RegexFunctions.RemoveWhitespace(inputExpression);

            while (position <= expression.Length)
            {
                var token = TokenFunctions.ToToken(expression[position..]);

                yield return token;

                if (token.Type is TokenType.Unknown or TokenType.EndOfFile)
                    yield break;

                position += token.Lexeme!.Length;
            }
        }
    }
}
