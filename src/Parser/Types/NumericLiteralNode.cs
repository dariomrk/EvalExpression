using Parser.Enums;

namespace Parser.Types
{
    public sealed record class NumericLiteralNode : Node
    {
        public override NodeType NodeType => NodeType.NumericLiteral;
        public override bool IsLeaf => true;
        public decimal Value { get; init; }

        public NumericLiteralNode(decimal value)
        {
            Value = value;
        }
    }
}
