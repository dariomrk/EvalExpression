﻿using Lexer.Enums;
using Parser.Enums;

namespace Parser.Types
{
    public sealed record class UnaryNode : Node
    {
        public Node? Next { get; set; }

        public UnaryNode(NodeType nodeType)
        {
            if (nodeType is not
                NodeType.NumericLiteral
                or NodeType.Positive
                or NodeType.Negative)
                throw new ArgumentException($"Cannot construct a {nameof(UnaryNode)} object for {nameof(Enums.NodeType)} of {nodeType}.");

            NodeType = nodeType;
        }
    }
}
