using Lexer.Enums;
using Lexer.Types;
using static Lexer.Lexer;

namespace Unit
{
    public class LexerTests
    {
        [Fact]
        public void SimpleExpression()
        {
            var expected = new List<Token>
            {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2"),
                Token.EndOfFileToken,
            }.AsEnumerable();

            var actual = Tokenize("1+2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DecimalNumbers()
        {
            var expected = new List<Token>
            {
                new Token(TokenType.Number, "1.23"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2.45"),
                Token.EndOfFileToken,
            }.AsEnumerable();

            var actual = Tokenize("1.23+2.45");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Whitespace()
        {
            var expected = new List<Token>
            {
                new Token(TokenType.Whitespace, " "),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2"),
                Token.EndOfFileToken,
            }.AsEnumerable();

            var actual = Tokenize(" 1+2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleWhitespaceOccurences()
        {
            var expected = new List<Token>
            {
                new Token(TokenType.Whitespace, " "),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Whitespace, "\t "),
                new Token(TokenType.Number, "2"),
                Token.EndOfFileToken,
            }.AsEnumerable();

            var actual = Tokenize(" 1+\t 2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Operators()
        {
            var expected = new List<Token>
            {
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.Asterisk, "*"),
                new Token(TokenType.Slash, "/"),
                new Token(TokenType.Caret, "^"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.CloseParenthesis, ")"),
                Token.EndOfFileToken,
            }.AsEnumerable();

            var actual = Tokenize("+-*/^()");

            Assert.Equal(expected, actual);
        }
    }
}
