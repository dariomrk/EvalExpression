using Lexer.Enums;

namespace Core
{
    public static class Core
    {
        public static decimal Evaluate(
            string expression,
            bool ignoreWhitespace = true)
        {
            var tokens = Lexer.Lexer
                .Tokenize(expression)
                .Where(token => token.Type is not TokenType.Whitespace && ignoreWhitespace);

            var parser = new Parser.Parser(tokens);

            var abstractSyntaxTree = parser.Parse();

            var result = Interpreter.Interpreter.Evaluate(abstractSyntaxTree);

            return result;
        }
    }
}
