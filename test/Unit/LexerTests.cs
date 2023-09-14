using Lexer.Enums;
using Lexer.Types;

namespace Unit
{
    public class LexerTests
    {
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

            var actual = Lexer.Lexer.Tokenize("3+4");

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

            var actual = Lexer.Lexer.Tokenize("3+4*1/2^2");

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

            var actual = Lexer.Lexer.Tokenize(" \t 3 +4*1 /  \n 2^ 2 ");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleParenthesis()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Operator, "("),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operator, ")"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.EndOfFile),
            };

            var actual = Lexer.Lexer.Tokenize(" \t (3 +4)*1");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleParenthesis()
        {
            IEnumerable<Token> expected = new List<Token>
            {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Operator, "("),
                new Token(TokenType.Operator, "("),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operator, ")"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Operator, ")"),
                new Token(TokenType.EndOfFile),
            };

            var actual = Lexer.Lexer.Tokenize("1+ \t ((3 +4)*1)");

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

            var actual = Lexer.Lexer.Tokenize(" \t 3 +4g*1 /  \n 2^ 2");

            Assert.Equal(expected, actual);
        }
    }
}
