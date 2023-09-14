using Parser.Enums;
using Parser.Types;

namespace Parser.Functions
{
    internal static class NodeFactory
    {
        internal static Node NumericLiteral(string lexeme) =>
            new NumericLiteralNode(decimal.Parse(lexeme));

        internal static Node BinaryOperator(Operator @operator) =>
            new BinaryOperatorNode(@operator);

        internal static Node UnaryOperator(Operator @operator) =>
            new UnaryOperatorNode(@operator);
    }
}
