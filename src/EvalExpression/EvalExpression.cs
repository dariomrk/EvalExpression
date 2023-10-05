using Lexer.Enums;
using Parser.Types;
using @lexer = Lexer.Lexer;
using @parser = Parser.Parser;

namespace EvalExpression
{
    public static class EvalExpression
    {
        /// <summary>
        /// Builds an AST (Abstract Syntax Tree) from an arithmetic expression string.
        /// </summary>
        /// <param name="expression">Expression to parse</param>
        /// <param name="ignoreWhitespace">Should ignore whitespace from the provided <paramref name="expression"/>?</param>
        /// <returns>The root node of the parsed expression</returns>
        /// <exception cref="Parser.Exceptions.SyntaxException"></exception>
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
