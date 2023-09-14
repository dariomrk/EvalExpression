using Parser.Enums;

namespace Parser.Types
{
    public sealed record class BinaryOperatorNode : Node
    {
        public override NodeType NodeType => NodeType.BinaryOperator;
        public override bool IsLeaf => this is { Left: null, Right: null };
        public Operator Operator { get; init; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public BinaryOperatorNode(Operator @operator)
        {
            Operator = @operator;
        }
    }
}
