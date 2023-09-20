using Lexer.Enums;
using Parser.Types;
using @lexer = Lexer.Lexer;
using @parser = Parser.Parser;

namespace EvalExpression
{
    public static class EvalExpression
    {
        public static Node Build(
            string expression,
            bool ignoreWhitespace = true)
        {
            var tokens = @lexer.Tokenize(expression)
                .Where(token => token.Type is not TokenType.Whitespace || !ignoreWhitespace);

            var parser = new @parser(tokens);

            return parser.Parse();
        }
    }
}
