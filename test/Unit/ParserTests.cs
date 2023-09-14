using Lexer.Enums;
using Lexer.Types;
using Parser.Enums;
using Parser.Types;

namespace Unit
{
    public class ParserTests
    {
        [Fact]
        public void Simple()
        {
            var tokens = new List<Token>
            {
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.EndOfFile),
            };

            var expected = new BinaryOperatorNode(Operator.Add)
            {
                Left = new NumericLiteralNode(3),
                Right = new NumericLiteralNode(4),
            };

            var actual = Parser.Parser.Parse(tokens);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SamePrecedence()
        {
            // 3.12 * 4.2 / 81

            var tokens = new List<Token>
            {
                new Token(TokenType.Number, "3.12"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4.2"),
                new Token(TokenType.Operator, "-"),
                new Token(TokenType.Number, "81"),
                new Token(TokenType.EndOfFile),
            };

            var expected = new BinaryOperatorNode(Operator.Subtract)
            {
                Left = new BinaryOperatorNode(Operator.Add)
                {
                    Left = new NumericLiteralNode(3.12m),
                    Right = new NumericLiteralNode(4.2m),
                },
                Right = new NumericLiteralNode(81),
            };

            var actual = Parser.Parser.Parse(tokens);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleOperatorPrecedence()
        {
            var tokens = new List<Token>
            {
                new Token(TokenType.Number, "3.3"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.EndOfFile),
            };

            var expected = new BinaryOperatorNode(Operator.Add)
            {
                Left = new NumericLiteralNode(3.3m),
                Right = new BinaryOperatorNode(Operator.Multiply)
                {
                    Left = new NumericLiteralNode(4),
                    Right = new NumericLiteralNode(2),
                },
            };

            var actual = Parser.Parser.Parse(tokens);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComplexOperatorPrecedence()
        {
            var tokens = new List<Token>
            {
                new Token(TokenType.Number, "345.24"),
                new Token(TokenType.Operator, "+"),
                new Token(TokenType.Number, "85"),
                new Token(TokenType.Operator, "^"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Operator, "-"),
                new Token(TokenType.Number, "231"),
                new Token(TokenType.Operator, "*"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Operator, "/"),
                new Token(TokenType.Number, "12"),
                new Token(TokenType.EndOfFile),
            };

            var expected = new BinaryOperatorNode(Operator.Subtract)
            {
                Left = new BinaryOperatorNode(Operator.Add)
                {
                    Left = new NumericLiteralNode(345.24m),
                    Right = new BinaryOperatorNode(Operator.Exponentiate)
                    {
                        Left = new NumericLiteralNode(85),
                        Right = new NumericLiteralNode(2),
                    },
                },
                Right = new BinaryOperatorNode(Operator.Divide)
                {
                    Left = new BinaryOperatorNode(Operator.Multiply)
                    {
                        Left = new NumericLiteralNode(231),
                        Right = new NumericLiteralNode(2),
                    },
                    Right = new NumericLiteralNode(12),
                }
            };

            var actual = Parser.Parser.Parse(tokens);

            Assert.Equal(expected, actual);
        }
    }
}
