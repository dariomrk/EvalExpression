using Parser.Enums;

namespace Parser.Types
{
    public sealed record class BinaryNode : Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public BinaryNode(NodeType nodeType)
        {
            if (nodeType is not
                NodeType.Add
                or NodeType.Subtract
                or NodeType.Multiply
                or NodeType.Divide
                or NodeType.Exponentiate)
                throw new ArgumentException($"Cannot construct a {nameof(BinaryNode)} object for {nameof(Enums.NodeType)} of {nodeType}.");

            NodeType = nodeType;
        }
    }
}
