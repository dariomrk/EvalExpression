using Lexer.Types;
using Parser.Enums;
using Parser.Extensions;
using Parser.Functions;
using Parser.Types;

namespace Parser
{
    public class Parser
    {
        private readonly IEnumerable<Token> _tokens;
        private int _position = 0;

        public Parser(IEnumerable<Token> tokens)
        {
            _tokens = tokens;
        }

        public void Advance()
        {
            _position++;
        }

        public Token Current => _tokens.ElementAt(_position);

        public static Node Parse(IEnumerable<Token> tokens)
        {
            return ParserFunctions.ParseExpression(
                new Parser(tokens),
                Operator.None.GetPrecedence());
        }
    }
}