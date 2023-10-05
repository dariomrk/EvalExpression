using Lexer.Enums;
using Lexer.Types;
using Parser.Enums;
using Parser.Exceptions;
using Parser.Types;

namespace Unit
{
    public class ParserTests
    {
        [Fact]
        public void SimpleExpression()
        {
            // expression: 3.45+1.25
            var input = new List<Token>
            {
                new Token(TokenType.Number, "3.45"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "1.25"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new BinaryNode(
                NodeType.Add,
                new NumericLiteralNode(3.45m),
                new NumericLiteralNode(1.25m));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParenthesizedExpression()
        {
            // expression: 1*(2+3)
            var input = new List<Token>
            {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Asterisk, "*"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.CloseParenthesis, ")"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new BinaryNode(
                NodeType.Multiply,
                new NumericLiteralNode(1),
                new BinaryNode(
                    NodeType.Add,
                    new NumericLiteralNode(2),
                    new NumericLiteralNode(3)));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParenthesizedExpressionWithUnaryOperator()
        {
            // expression: -(2+3)
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.CloseParenthesis, ")"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new UnaryNode(
                NodeType.Negative,
                new BinaryNode(
                    NodeType.Add,
                    new NumericLiteralNode(2),
                    new NumericLiteralNode(3)));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InvalidSyntaxExpression()
        {
            // expression: -)
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.OpenParenthesis, ")"),
            }.AsEnumerable();

            var parser = new Parser.Parser(input);

            Assert.Throws<SyntaxException>(parser.Parse);
        }

        [Fact]
        public void ComplexExpression()
        {
            // expression: -3^2*(2+3*(1+2))
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Caret, "^"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Asterisk, "*"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Asterisk, "*"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.CloseParenthesis, ")"),
                new Token(TokenType.CloseParenthesis, ")"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new BinaryNode(
                NodeType.Multiply,
                new UnaryNode(
                    NodeType.Negative,
                    new BinaryNode(
                        NodeType.Exponentiate,
                        new NumericLiteralNode(3),
                        new NumericLiteralNode(2))),
                new BinaryNode(
                    NodeType.Add,
                    new NumericLiteralNode(2),
                    new BinaryNode(
                        NodeType.Multiply,
                        new NumericLiteralNode(3),
                        new BinaryNode(
                            NodeType.Add,
                            new NumericLiteralNode(1),
                            new NumericLiteralNode(2)))));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImplicitNegativeNumber()
        {
            // expression: -2
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new UnaryNode(
                NodeType.Negative,
                new NumericLiteralNode(2));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NegativeNumberBeforeOperator()
        {
            // expression: -2*3
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Asterisk, "*"),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new BinaryNode(
                NodeType.Multiply,
                new UnaryNode(
                    NodeType.Negative,
                    new NumericLiteralNode(2)),
                new NumericLiteralNode(3));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExplicitNegativeNumber()
        {
            // expression: -(2)
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.CloseParenthesis, ")"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new UnaryNode(
                NodeType.Negative,
                new NumericLiteralNode(3));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImplicitMultiplication()
        {
            // expression: -2(3+1)
            var input = new List<Token>
            {
                new Token(TokenType.Hyphen, "-"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.OpenParenthesis, "("),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.CloseParenthesis, ")"),
                new Token(TokenType.EndOfFile, null),
            }.AsEnumerable();

            var expected = new BinaryNode(
                NodeType.Multiply,
                new UnaryNode(
                    NodeType.Negative,
                    new NumericLiteralNode(2)),
                new BinaryNode(
                    NodeType.Add,
                    new NumericLiteralNode(3),
                    new NumericLiteralNode(1)));

            var parser = new Parser.Parser(input);
            var actual = parser.Parse();

            Assert.Equal(expected, actual);
        }
    }
}
