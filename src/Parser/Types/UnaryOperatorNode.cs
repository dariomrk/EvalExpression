using Parser.Enums;

namespace Parser.Types
{
    public sealed record class UnaryOperatorNode : Node
    {
        public override NodeType NodeType => NodeType.UnaryOperator;
        public override bool IsLeaf => Next is null;
        public Operator Operator { get; init; }
        public Node? Next { get; set; }

        public UnaryOperatorNode(Operator @operator)
        {
            Operator = @operator;
        }
    }
}
