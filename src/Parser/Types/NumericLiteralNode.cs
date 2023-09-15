using Parser.Enums;

namespace Parser.Types
{
    public sealed record class NumericLiteralNode : Node
    {
        public override NodeType NodeType => NodeType.NumericLiteral;
        public decimal Value { get; init; }
    }
}
