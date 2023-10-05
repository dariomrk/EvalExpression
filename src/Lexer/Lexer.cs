using Lexer.Enums;
using Lexer.Functions;
using Lexer.Types;

namespace Lexer
{
    public static class Lexer
    {
        /// <summary>
        /// Converts an arithmetic expression string to a sequence of tokens.<br/>
        /// This function is implemented as a generator method,
        /// i.e. it converts the provided expression to tokens lazily.<br/>
        /// </summary>
        /// <param name="expression">Expression to be tokenized</param>
        /// <returns>A collection of tokens representing the provided expression</returns>
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
