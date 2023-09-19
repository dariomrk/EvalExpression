using Parser.Enums;
using Parser.Types;

namespace Unit
{
    public class InterpreterTests
    {
        [Fact]
        public void SimpleExpression()
        {
            // expression: 3.45+1.25
            var input = new BinaryNode(
                NodeType.Add,
                new NumericLiteralNode(3.45m),
                new NumericLiteralNode(1.25m));

            var expected = 4.70m;

            var actual = Interpreter.Interpreter.Evaluate(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParenthesizedExpression()
        {
            // expression: -(2+3)
            var input = new UnaryNode(
                NodeType.Negative,
                new BinaryNode(
                    NodeType.Add,
                    new NumericLiteralNode(2),
                    new NumericLiteralNode(3)));

            var expected = -5;

            var actual = Interpreter.Interpreter.Evaluate(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComplexExpression()
        {
            // expression: -(3)^2*(2+3*(1+2))
            var input = new BinaryNode(
                NodeType.Multiply,
                new BinaryNode(
                    NodeType.Exponentiate,
                    new UnaryNode(
                        NodeType.Negative,
                        new NumericLiteralNode(3)),
                    new NumericLiteralNode(2)),
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

            var expected = 99;

            var actual = Interpreter.Interpreter.Evaluate(input);

            Assert.Equal(expected, actual);
        }
    }
}
