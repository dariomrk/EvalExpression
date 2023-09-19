using Parser.Enums;
using Parser.Types;

namespace Parser.Functions
{
    internal static class NodeFactory
    {
        internal static Node NumericLiteral(string value) =>
            new NumericLiteralNode(decimal.Parse(value));

        internal static Node Binary(NodeType nodeType, Node left, Node right) =>
            new BinaryNode(nodeType, left, right);

        internal static Node Unary(NodeType nodeType, Node next) =>
            new UnaryNode(nodeType, next);
    }
}
