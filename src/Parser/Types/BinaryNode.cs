using Parser.Enums;

namespace Parser.Types
{
    public sealed record class BinaryNode : Node
    {
        public Node? Left { get; init; }
        public Node? Right { get; init; }

        public BinaryNode(NodeType nodeType, Node left, Node right)
        {
            if (nodeType is not
                (NodeType.Add
                or NodeType.Subtract
                or NodeType.Multiply
                or NodeType.Divide
                or NodeType.Exponentiate))
                throw new ArgumentException($"Cannot construct a {nameof(BinaryNode)} object for {nameof(Enums.NodeType)} of {nodeType}.");

            NodeType = nodeType;
            Left = left;
            Right = right;
        }
    }
}
