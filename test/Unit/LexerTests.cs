using Lexer.Enums;
using Lexer.Interfaces;
using Lexer.Types;

namespace Unit
{
    public class LexerTests
    {
        private readonly ILexer _lexer = new Lexer.Lexer();

        [Fact]
        public void Simple()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.EndOfFile),
            };

            var actual = _lexer.Tokenize("3+4");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleOperators()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Operator, "/"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Operator, "^"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.EndOfFile),
            };

            var actual = _lexer.Tokenize("3+4*1/2^2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Whitespace()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Operator, "/"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Operator, "^"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.EndOfFile),
            };

            var actual = _lexer.Tokenize(" \t 3 +4*1 /  \n 2^ 2 ");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parenthesis()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Parenthesis, "("),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Parenthesis, ")"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.EndOfFile),
            };

            var actual = _lexer.Tokenize(" \t (3 +4)*1");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UnknownToken()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Unknown),
            };

            var actual = _lexer.Tokenize(" \t 3 +4g*1 /  \n 2^ 2");

            Assert.Equal(expected, actual);
        }
    }
}
